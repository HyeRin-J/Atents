#pragma warning disable 0219

using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Text;

public class ExcelTableReader : EditorWindow
{

	GUIContent m_btnCntent = new GUIContent();
	private Vector2 scrollPosition;

    [MenuItem("Tools/ExcelTable")]
	static void Init () 
    {
        EditorWindow.GetWindow<ExcelTableReader>(false, "ExcelTable");
	}

	string excelFilePath = "";
    List<string> m_sheetNameList = new List<string>();
	Vector2 scrollPos = Vector2.zero;

	
	void OnGUI ()
    {
        List<TableXlsData> _list = TableMgr.Instance.GetTableXlsData();
        for( int i=0; i< _list.Count; ++i )
        {
            TableXlsData _data = _list[i];
            if (GUILayout.Button("Load : " + excelFilePath, GUI.skin.button))
            {
                excelFilePath = string.Format("{0}{1}", Application.dataPath, _data.xlsPath );

                LoadExcel(excelFilePath, _data);

                _data.save();
                AssetDatabase.Refresh();
            }
        }
        
		foreach (string sheetName in m_sheetNameList)
		{
			GUILayout.BeginHorizontal();
			GUILayout.TextField(sheetName);

			m_btnCntent.text = "Read sheet";
			m_btnCntent.tooltip = "";
			if (GUILayout.Button(m_btnCntent,  GUILayout.Width(150)))
			{
				//m_excelInfo = ExcelUtil.Instance.Read(excelFilePath, sheetName);
			}
			GUILayout.EndHorizontal();
		}

		scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUI.skin.box);
		EditorGUILayout.EndScrollView();
	}

    public List<Dictionary<string, string>> CreateExcelData(ISheet sheet)
    {
        List<Dictionary<string, string>> _create = new List<Dictionary<string, string>>();
        IRow titleRow = sheet.GetRow(0);
        
        var _var = sheet.GetRowEnumerator();
        _var.MoveNext();
        while (_var.MoveNext())
        {
            IRow dataRow = (IRow)_var.Current;
            Dictionary<string, string> _rowList = new Dictionary<string, string>();
            for (int i = 0; i < titleRow.LastCellNum; i++)
            {
                ICell _rowCell = titleRow.GetCell(i);
                if (null == _rowCell)
                    continue;

                string _key = _rowCell.StringCellValue;
                if (_key == null || _key.Length <= 0)
                    continue;
                string _data = string.Empty;

                if (dataRow != null)
                {
                    ICell _cell = dataRow.GetCell(i);
                    if (null != _cell)
                    {
                        switch (_cell.CellType)
                        {
                            case CellType.Boolean:
                                _data = _cell.BooleanCellValue.ToString();
                                break;

                            case CellType.Numeric:
                                _data = _cell.NumericCellValue.ToString();
                                break;

                            case CellType.String:
                                _data = _cell.StringCellValue;
                                break;
                        }

                    }
                }
                _rowList.Add(_key, _data);
            }
            _create.Add(_rowList);
        }
        
        

        return _create;
    }

    public void LoadExcel( string _path, TableXlsData _data)
    {
        using (FileStream stream = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            IWorkbook book = null;
            if (Path.GetExtension(_path) == ".xls")
            {
                book = new HSSFWorkbook(stream);
            }
            else
            {
                book = new XSSFWorkbook(stream);
            }

            for (int i = 0; i < book.NumberOfSheets; ++i)
            {
                ISheet s = book.GetSheetAt(i);      
                _data.load(s.SheetName, CreateExcelData(s));
            }
        }
    }
}
