import 'dart:io';
import 'dart:convert';

class FindCADPath {
  final lowestValidYear = 2014;
  Directory dir;
  FindCADPath(Directory dir){
    this.dir = dir;
  }

  String getAutoCadPath(){
    String autoDeskPathRoot = "${dir.path}\\Autodesk";
    if(FileSystemEntity.typeSync(autoDeskPathRoot) != FileSystemEntityType.notFound){

      // because Autodesk publish AutoCAD which version is 1 year higher than current. 
      int year = DateTime.now().year + 1; 
      while(year >= lowestValidYear){
        String autoDeskPath = "$autoDeskPathRoot\\AutoCAD $year\\accoreconsole.exe";
        if(FileSystemEntity.typeSync(autoDeskPath) != FileSystemEntityType.notFound){
          return autoDeskPath;
        }
        year--;
      }
    }
    return null;
  }
}

class CopyFileToFolder{
  String oldLocation;
  String newLocation;

  Future<ProcessResult> Copy(String oldLocation, String newLocation) async{
    //await Process.run("cmd" ["/c robocoy /e", oldLocation, newLocation], runInShell : false);
    return Process.run("cmd /c robocopy /e \"$oldLocation\" \"$newLocation\"", [], runInShell : false);
  }

  void RenameTheDirectory(String oldLocation, String newLocation) async{
    String oldProjectNumber = oldLocation.split("\\").last;
    String newProjectNumber = newLocation.split("\\").last;
    String oldProjectNumber4digit = oldProjectNumber.substring(1);
    String newProjectNumber4digit = newProjectNumber.substring(1);

    Directory dir = Directory(newLocation);
    List<FileSystemEntity> fileList = await dir.list(recursive: true).toList();
    for(int i = 0; i < fileList.length; i++){
      FileSystemEntity file = fileList[i];

      //Delete File
      String ext = file.path.split("\\").last.toLowerCase();
      if(ext.contains(".rmk") ||
         ext.contains(".bak") ||
         ext.contains(".log") ||
         ext.contains(".dwl")
        ){
        await file.delete(recursive: true);
        fileList.removeAt(i);
        i--;
      //Rename File
      } else if(file.path.contains(oldProjectNumber)){
        await file.rename(file.path.replaceAll(oldProjectNumber, newProjectNumber));
      } else if(file.path.contains(oldProjectNumber4digit)){
        await file.rename(file.path.replaceAll(oldProjectNumber4digit, newProjectNumber4digit));
      }
    }
  }
}

class FixXref{
  InputInformationClass inputClass;
  XrefPathInformation xrefPathInformation = XrefPathInformation();

  String accorePath;


  String projectFile = "XrefPathInformation.json";

  FixXref(InputInformationClass inputClass, String accorePath){
    this.inputClass = inputClass;
    this.accorePath = accorePath;

    xrefPathInformation.newNumber = inputClass.newLocation.trim().split("\\").last;
    xrefPathInformation.oldNumber = inputClass.oldLocation.trim().split("\\").last;

    xrefPathInformation.newNumber4Digit = xrefPathInformation.newNumber.substring(1);
    xrefPathInformation.oldNumber4Digit = xrefPathInformation.oldNumber.substring(1);
    
  }

  void fixAll() async{
    Directory dir = Directory(inputClass.newLocation);
    List<FileSystemEntity> fileList = await dir.list(recursive: true).toList();

    for(int i = 0; i < fileList.length; i++){
      if(await File(fileList[i].path).exists() && await isDwgFile(fileList[i].path)){
        xrefPathInformation.dwgPath = fileList[i].path;
        //RUN THE PROCESS TO CHANGE XREF
        
        String pathBatFile = "${DateTime.now().millisecondsSinceEpoch}Bat.bat";;
        String scriptFile = "${DateTime.now().millisecondsSinceEpoch}Script.scr";

        await createBat(pathBatFile, Directory.current.path + "\\" + scriptFile, inputClass.dllCommand, inputClass.dllPath);
        await createInforSite();

        await Process.run(pathBatFile, []);
        File(pathBatFile).delete();
        File(scriptFile).delete();
        //break;
      }
    }
  }

  void createBat(String pathBatFile, String scriptFile, String command, String dllPath) async{
    await createScript(scriptFile, command, dllPath);
    String commandLine = "\"$accorePath\" /i \"trash.dwg\" /s \"$scriptFile\"";
    await File(pathBatFile).writeAsString(commandLine);
  }

  void createScript(String scriptFile, String command, String dllPath) async{
    String commandScript = "SECURELOAD\n0\nNETLOAD\n$dllPath\n$command\nSAVE\n\nY\nEXIT\n";

    await File(scriptFile).writeAsString(commandScript);
  }

  Future<bool> isDwgFile(String path) async{
    if(!await File(path).exists()){return false;}
    String fileName = path.split("\\").last.toLowerCase();

    if(fileName.contains(".") && fileName.split(".").last == "dwg"){
      return true;
    }

    return false;
  }

  void createInforSite() async{
    //print("-----------------------------------------------\n" + jsonEncode(xrefPathInformation));
    await File(projectFile).writeAsString(jsonEncode(xrefPathInformation));
  }
}

main(List<String> args) async{
  //USERNAME

  //args
  // 0 -- old/new Location FileText


  String jsonString = await  File(args[0]).readAsString();
  //File(args[0]).delete();
  
  InputInformationClass inputClass = InputInformationClass.fromJson(jsonString);
  await File("absdf.json").writeAsString(jsonEncode(inputClass));

  if(! await Directory(inputClass.newLocation).exists()){ 
  } else{
    await Directory(inputClass.newLocation).delete(recursive: true);
  }
  await Directory(inputClass.newLocation).create();

  String envVars = Platform.environment["PROGRAMFILES"];
  Directory dir = Directory(envVars);
  FindCADPath cadPath = FindCADPath(dir);

  CopyFileToFolder copy = CopyFileToFolder();
  ProcessResult processResult = await copy.Copy(inputClass.oldLocation, inputClass.newLocation);
  await copy.RenameTheDirectory(inputClass.oldLocation, inputClass.newLocation);

  FixXref fixXref = FixXref(inputClass, cadPath.getAutoCadPath());

  await fixXref.fixAll();
}

class InputInformationClass
{
    String oldLocation;
    String newLocation;
    String dllCommand;
    String dllPath;
    String outputFile;

    InputInformationClass.fromJson(String jsonString){
      dynamic jsonEntity = json.decode(jsonString);
      this.oldLocation = jsonEntity["oldLocation"];
      this.newLocation = jsonEntity["newLocation"];
      this.dllCommand = jsonEntity["dllCommand"];
      this.dllPath = jsonEntity["dllPath"];
      this.outputFile = jsonEntity["outputFile"];
    }

    Map<String, dynamic> toJson() => {
      'oldLocation' : oldLocation,
      'newLocation' : newLocation,
      'dllCommand' : dllCommand,
      'dllPath' : dllPath,
      'outputFile' : outputFile
    };
}

class XrefPathInformation{
  String oldNumber;
  String newNumber;
  String oldNumber4Digit;
  String newNumber4Digit;
  String dwgPath;

  Map<String, dynamic> toJson() => {
    'oldNumber' : oldNumber,
    'newNuwber' : newNumber,
    'oldNumber4Digit' : oldNumber4Digit,
    'newNumber4Digit' : newNumber4Digit,
    'dwgPath' : dwgPath
  };
}
