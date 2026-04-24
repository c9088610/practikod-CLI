using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // 1. בדיקה אם המשתמש שלח נתיב
        if (args.Length < 2)
        {
            Console.WriteLine("התוכנית לא קיבלה את הפרמטרים שהיא מצפה להם: practicodeCLI merge <path>");
            return;
        }

      
        //2. שמירת הנתיב

        string command = args[0];
        string path = args[1];

        // 📁 יצירת תיקיית output
        string outputDir = Path.Combine(path, "output");
        Directory.CreateDirectory(outputDir);

        Console.WriteLine("תיקיית output מוכנה: " + outputDir);

        if (command == "merge")
        {


            // 3. בדיקה שהתיקייה קיימת
            if (!Directory.Exists(path))
        {
            Console.WriteLine("התיקייה לא קיימת.");
            return;
        }

        // אם הגענו לפה — הכול תקין
        Console.WriteLine("התיקייה תקינה: " + path);

        // 4. סוגי קבצי קוד נתמכים
        string[] extensions = { ".cs", ".py", ".java", ".c", ".cpp", ".html", ".js" };

        // 5. קבלת כל הקבצים בתיקייה (כולל תתי תיקיות)
        string[] allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

        // 6. סינון רק קבצי קוד
        var codeFiles = allFiles
            .Where(file => extensions.Contains(Path.GetExtension(file)))
            .ToArray();

        // 7. בדיקה כמה קבצים נמצאו
        Console.WriteLine("נמצאו " + codeFiles.Length + " קבצי קוד");

        // 8. משתנה שיחזיק את כל הקוד המאוחד
        string mergedCode = "";

        foreach (var file in codeFiles)
        {
            // 9. קריאת תוכן הקובץ
            string content = File.ReadAllText(file);

            // 10. הוספת כותרת לקובץ כדי לדעת מאיפה הוא הגיע
            mergedCode += "\n\n===== " + Path.GetFileName(file) + " =====\n\n";

            // 11. הוספת תוכן הקובץ
            mergedCode += content;
        }

        // 12. יצירת קובץ פלט
        string outputPath = Path.Combine(path, "merged_code.txt");

        // 13. שמירת כל הקוד המאוחד
        File.WriteAllText(outputPath, mergedCode);

        Console.WriteLine("הקבצים אוחדו בהצלחה!");
        Console.WriteLine("נשמר ב: " + outputPath);

        }
        else
        {
            Console.WriteLine("פקודה לא מוכרת");
        }


    }
}