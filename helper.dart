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
    String oldProjectNumber = oldLocation.split("/").last;
    String newProjectNumber = newLocation.split("/").last;
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
  String accorePath;


  String projectFile = "projectFile.json";

  FixXref(InputInformationClass inputClass, String accorePath){
    this.inputClass = inputClass;
    this.accorePath = accorePath;

  }

  void fixAll() async{
    Directory dir = Directory(inputClass.newLocation);
    List<FileSystemEntity> fileList = await dir.list(recursive: true).toList();

    for(int i = 0; i < fileList.length; i++){
      if(await File(fileList[i].path).exists() && await isDwgFile(fileList[i].path)){
        //RUN THE PROCESS TO CHANGE XREF
        
        String pathBatFile = "${DateTime.now()}Bat.bat";;
        String scriptFile = "${DateTime.now()}Script.scr";

        await createBat(pathBatFile, scriptFile, inputClass.dllCommand, inputClass.dllPath);
        await createInforSite();
        await Process.run(pathBatFile, []);

      }
    }
  }

  void createBat(String pathBatFile, String scriptFile, String command, String dllPath) async{
    await createScript(scriptFile, command, dllPath);
    String commandLine = "$accorePath /i trash.dwg /s $scriptFile /readonly";
    await File(pathBatFile).writeAsString(commandLine);
  }

  void createScript(String scriptFile, String command, String dllPath) async{
    String commandScript = '''
      SECURELOAD
      0
      NETLOAD
      $dllPath
      $command
      exit
    ''';

    await File(scriptFile).writeAsString(commandScript);
  }

  Future<bool> isDwgFile(String path) async{
    if(!await Directory(path).exists()){return false;}
    String fileName = path.split("/").last.toLowerCase();

    if(fileName.contains(".") && fileName.split(".").last == "dwg"){
      return true;
    }

    return false;
  }

  void createInforSite() async{
    await File(projectFile).writeAsString(json.encode(this));
  }

}

main(List<String> args) async{
  //USERNAME

  //args
  // 0 -- old/new Location FileText


  String jsonString = await  File(args[0]).readAsString();
  File(args[0]).delete();
  
  jsonString = jsonString.replaceAll(r'\\', '/');
  InputInformationClass inputClass = InputInformationClass.fromJson(jsonString);

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

  print(processResult.stdout);
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
}

class OutputInformation{
  String numberOfFiles;
  String processState;
  String consoleOutPut;
  List<String> fileName;

  OutputInformation(){}

  void writeToFile(String filePath){
    File(filePath).writeAsString(json.encode(this));
  }
}

class XrefPathInformation{
  String oldNumber;
  String newNumber;
  String oldNumber4Digit;
  String newNumber4Digit;
  String dwgPath;
}
