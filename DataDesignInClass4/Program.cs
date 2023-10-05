using DataDesignInClass4;

var Path = Directory.GetCurrentDirectory() + @"\files";
var FileList = Directory.GetFiles(Path).Where(fn => !fn.Contains("_out")).ToList();
var OutFileList = Directory.GetFiles(Path).Where(fn => fn.Contains("_out")).ToList();
List<string> FileDataSetCSV = new List<string>();
List<string> FileDataSetPipe = new List<string>();

ActiveFile AFile = new ActiveFile();

int x = 0;


foreach (var file in FileList)
{
    using (StreamReader sr = new StreamReader(file)) //will change due to different PATH ?
    {
        var line = sr.ReadLine();
        
        while (line != null)
        {


            if (x >= 0 && x <= 2)
            {
                FileDataSetCSV.Add(line);
                line = sr.ReadLine();
                x++;
            }
            else
            {
                FileDataSetPipe.Add(line);
                line = sr.ReadLine();
                x++;
            }
            
        }
    }
}



foreach (var file in OutFileList)
{
    using (StreamWriter sw = new StreamWriter(file))
    {
        int i = 1;
        if (file.Contains("CSV"))
        {
            foreach (string line in FileDataSetCSV)
            {
                sw.Write($"\n Line#{i} :Field#1=");
                sw.Write(line.Replace(AFile.SetDelim(file), $" ==> Field#{i}="));
                i++;
            }
        }


        if (file.Contains("Pipe"))
        {
            foreach (string line in FileDataSetPipe)
            {
                sw.Write($"\n Line#{i} :Field#1=");
                sw.Write(line.Replace(AFile.SetDelim(file), $" ==> Field#{i}="));
                i++;
            }
        }
    }
}