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
        String autoDeskPath = "$autoDeskPathRoot\\AutoCAD $year\\acad.exe";
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

    print("1: $oldProjectNumber");
    print("2: $newProjectNumber");

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
}

class ExportClass
{
    String oldLocation;
    String newLocation;
}

main(List<String> args) async{

  String jsonString = await  File("jsondata.txt").readAsString();
  await File("data-copy.txt").writeAsString(jsonString);

  jsonString = jsonString.replaceAll(r'\', r'/');
  
  dynamic rss = json.decode(jsonString);
  String oldLocation = rss["oldLocation"];
  String newLocation = rss["newLocation"];

  if(! await Directory(newLocation).exists()){ 
  } else{
    await Directory(newLocation).delete(recursive: true);
  }
  await Directory(newLocation).create();

  String envVars = Platform.environment["PROGRAMFILES"];
  Directory dir = Directory(envVars);
  FindCADPath cadPath = FindCADPath(dir);

  print(cadPath.getAutoCadPath());
  CopyFileToFolder copy = CopyFileToFolder();
  ProcessResult processResult = await copy.Copy(oldLocation, newLocation);
  await copy.RenameTheDirectory(oldLocation, newLocation);
  print(processResult.stdout);
}

