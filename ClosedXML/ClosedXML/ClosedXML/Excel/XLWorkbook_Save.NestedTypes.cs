﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ClosedXML.Excel
{
    public partial class XLWorkbook
    {
        #region Nested type: SaveContext
        private sealed class SaveContext
        {
            #region Private fields
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly RelIdGenerator _relIdGenerator;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly Dictionary<Int32, StyleInfo> _sharedStyles;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly Dictionary<IXLFont, FontInfo> _sharedFonts;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly HashSet<string> _tableNames;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private uint _tableId;
            #endregion
            #region Constructor
            public SaveContext()
            {
                _relIdGenerator = new RelIdGenerator();
                _sharedStyles = new Dictionary<Int32, StyleInfo>();
                _sharedFonts = new Dictionary<IXLFont, FontInfo>();
                _tableNames = new HashSet<String>();
                _tableId = 0;
            }
            #endregion
            #region Public properties
            public RelIdGenerator RelIdGenerator
            {
                [DebuggerStepThrough]
                get { return _relIdGenerator; }
            }
            public Dictionary<Int32, StyleInfo> SharedStyles
            {
                [DebuggerStepThrough]
                get { return _sharedStyles; }
            }
            public Dictionary<IXLFont, FontInfo> SharedFonts
            {
                [DebuggerStepThrough]
                get { return _sharedFonts; }
            }
            public HashSet<string> TableNames
            {
                [DebuggerStepThrough]
                get { return _tableNames; }
            }
            public uint TableId
            {
                [DebuggerStepThrough]
                get { return _tableId; }
                [DebuggerStepThrough]
                set { _tableId = value; }
            }
            #endregion
        }
        #endregion
        #region Nested type: RelType
        private enum RelType
        {
            Workbook,
            Worksheet
        }
        #endregion
        #region Nested type: RelIdGenerator
        private sealed class RelIdGenerator
        {
            private readonly Dictionary<RelType, List<String>> _relIds = new Dictionary<RelType, List<String>>();
            public String GetNext(RelType relType)
            {
                if (!_relIds.ContainsKey(relType))
                {
                    _relIds.Add(relType, new List<String>());
                }

                Int32 id = 1;
                while (true)
                {
                    String relId = String.Format("rId{0}", id);
                    if (!_relIds[relType].Contains(relId))
                    {
                        _relIds[relType].Add(relId);
                        return relId;
                    }
                    id++;
                }
            }
            public void AddValues(List<String> values, RelType relType)
            {
                if (!_relIds.ContainsKey(relType))
                {
                    _relIds.Add(relType, new List<String>());
                }
                _relIds[relType].AddRange(values);
            }
        }
        #endregion
        #region Nested type: FontInfo
        private struct FontInfo
        {
            public UInt32 FontId;
            public IXLFont Font;
        };
        #endregion
        #region Nested type: FillInfo
        private struct FillInfo
        {
            public UInt32 FillId;
            public IXLFill Fill;
        }
        #endregion
        #region Nested type: BorderInfo
        private struct BorderInfo
        {
            public UInt32 BorderId;
            public IXLBorder Border;
        }
        #endregion
        #region Nested type: NumberFormatInfo
        private struct NumberFormatInfo
        {
            public Int32 NumberFormatId;
            public IXLNumberFormat NumberFormat;
        }
        #endregion
        #region Nested type: StyleInfo
        private struct StyleInfo
        {
            public UInt32 StyleId;
            public UInt32 FontId;
            public UInt32 FillId;
            public UInt32 BorderId;
            public Int32 NumberFormatId;
            public IXLStyle Style;
        }
        #endregion

        
        
       
    }
}