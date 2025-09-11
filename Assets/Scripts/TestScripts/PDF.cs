using System.Collections.Generic;
using UnityEngine;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

public class PDF : MonoBehaviour
{
    // �A�b�v���[�h���ꂽPDF�t�@�C���̃p�X
    private List<string> pdfFilePaths = new List<string>();

    // PDF�t�@�C�����A�b�v���[�h�i�ǉ��j
    public void UploadPDF(string filePath)
    {
        if (File.Exists(filePath) && Path.GetExtension(filePath).ToLower() == ".pdf")
        {
            pdfFilePaths.Add(filePath);
            Debug.Log($"PDF�ǉ�: {filePath}");
        }
        else
        {
            Debug.LogWarning("PDF�t�@�C����������܂���: " + filePath);
        }
    }

    // PDF�t�@�C�����������ăG�N�X�|�[�g
    public void ExportMergedPDF(string exportPath)
    {
        if (pdfFilePaths.Count == 0)
        {
            Debug.LogWarning("��������PDF������܂���");
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
        Debug.Log($"PDF�����E�G�N�X�|�[�g����: {exportPath}");
    }
}
