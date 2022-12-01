using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;


public class WordClass
{

    public string Paper_Code;
    public string Owner_Code;
    public string Uploade_Date;
    public string T_Name;
    public string P_Desc;
    public int Field;
    public int Audience;
    public int Page_C;
    public int Paragrapgh_C;
    public int Line_C;
    public Int32 Word_C;
    public Int32 Char_C;
    public string Key_Words;
    public int T_Word_C;
    public int T_Char_C;
    public string T_Key_Words;
    public int Status;
    public Int32 Price;
    public int FeesPercent;
    public string LastModifiedDate;

    Word.Application wordApplication = new Word.Application();
    public Word.Document wordDocument { get; set; }


    public WordProperties WP { get; set; }

    public WordClass()
    {
        
    }

    
    public WordClass(Word.Document myWD)
    {
        wordDocument = myWD;
    }

    public WordClass(string FileName)
    {
        wordDocument = wordApplication.Documents.Open(FileName);
    }

    public static WordProperties GetProperties(Word.Document myWordDoc)
    {
        WordProperties myWP = new WordProperties();

        myWP.Word_C = myWordDoc.Words.Count; //Word Count
        myWP.Char_C = myWordDoc.Characters.Count; //Character Count

        myWP.Line_C = myWordDoc.ComputeStatistics(WdStatistic.wdStatisticLines); //Line Count

        myWP.Paragrapgh_C = myWordDoc.ComputeStatistics(WdStatistic.wdStatisticParagraphs); //Paragraph Count

        myWP.Page_C = myWordDoc.ComputeStatistics(WdStatistic.wdStatisticPages); //Page Count
        

        //Find Keywords
        
        return myWP;
    }
    public WordProperties GetProperties()
    {
        WordProperties myWP = new WordProperties();

        myWP.Word_C = wordDocument.Words.Count; //Word Count
        myWP.Char_C = wordDocument.Characters.Count; //Character Count

        myWP.Line_C = wordDocument.ComputeStatistics(WdStatistic.wdStatisticLines); //Line Count

        myWP.Paragrapgh_C = wordDocument.ComputeStatistics(WdStatistic.wdStatisticParagraphs); //Paragraph Count

        myWP.Page_C = wordDocument.ComputeStatistics(WdStatistic.wdStatisticPages); //Page Count
        

        return myWP;
    }

    public Word.Document MakePreview(Word.Document WD)
    {
        Random RND = new Random(0);
        Word.Document PrevDoc = WD;
        PrevDoc.Activate();
        if (PrevDoc.Characters.Count > 1000)
        {
            PrevDoc.Range(1000, PrevDoc.Characters.Count).Delete();
        }

        int curind = 100;
        while (curind < 1000)
        {
            int StarCount = RND.Next(5, 50);
            string StarText = "";
            for (int i = 0; i < StarCount; i++) StarText += "*";
            Word.Range RG = PrevDoc.Range(curind, curind + StarCount);
            RG.Select();
            RG.Text = StarText;

            curind += StarCount + 1;

            int NormalCount = RND.Next(10, 60);
            curind += NormalCount + 1;
        }

        
        return PrevDoc;
    }

    public Word.Document MakePreview()
    {
        Random RND = new Random(0);
        Word.Document PrevDoc = wordDocument;
        PrevDoc.Activate();
        if (PrevDoc.Characters.Count > 1000)
        {
            PrevDoc.Range(1000, PrevDoc.Characters.Count).Delete();
        }

        int curind = 100;
        while (curind < 950)
        {
            int up = Math.Min(50, 949 - curind);
            int StarCount = RND.Next(5, up);
            string StarText = "";
            for (int i = 0; i < StarCount; i++) StarText += "*";
            Word.Range RG = PrevDoc.Range(curind, curind + StarCount);
            RG.Select();
            RG.Text = StarText;

            curind += StarCount + 1;

            int NormalCount = RND.Next(10, 60);
            curind += NormalCount + 1;
        }

        
        return PrevDoc;
    }

    public void Convert2Pdf(Word.Document WD, string Path, string Name)
    {
        WD.ExportAsFixedFormat(System.Web.HttpContext.Current.Server.MapPath(Path + Name + ".pdf"), WdExportFormat.wdExportFormatPDF, false);
    }

    public void Dispose()
    {
        wordDocument.Close();
        wordApplication.Dispose();
        wordDocument.Dispose();        
    }

}

