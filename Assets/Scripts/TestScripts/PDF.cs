using System.Collections.Generic;
using UnityEngine;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

public class PDF : MonoBehaviour
{
    // アップロードされたPDFファイルのパス
    private List<string> pdfFilePaths = new List<string>();

    // PDFファイルをアップロード（追加）
    public void UploadPDF(string filePath)
    {
        if (File.Exists(filePath) && Path.GetExtension(filePath).ToLower() == ".pdf")
        {
            pdfFilePaths.Add(filePath);
            Debug.Log($"PDF追加: {filePath}");
        }
        else
        {
            Debug.LogWarning("PDFファイルが見つかりません: " + filePath);
        }
    }

    // PDFファイルを結合してエクスポート
    public void ExportMergedPDF(string exportPath)
    {
        if (pdfFilePaths.Count == 0)
        {
            Debug.LogWarning("結合するPDFがありません");
            return;
        }

        PdfDocument outputDocument = new PdfDocument();
        foreach (var path in pdfFilePaths)
        {
            PdfDocument inputDocument = PdfReader.Open(path, PdfDocumentOpenMode.Import);
            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                outputDocument.AddPage(inputDocument.Pages[idx]);
            }
        }
        outputDocument.Save(exportPath);
        Debug.Log($"PDF結合・エクスポート完了: {exportPath}");
    }
}
