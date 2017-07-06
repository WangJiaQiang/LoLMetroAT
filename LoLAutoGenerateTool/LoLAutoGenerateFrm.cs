using CsQuery;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LoLAutoGenerateTool
{
    public partial class LoLAutoGenerateFrm : Form
    {
        private const string LoL_Default_Dto_Folder = "LoLDto";
        private const string Div_Rex = "\r\n<DIV class=\"block response_body\"><B>";
        private const string Span_Rex = "<SPAN style=\"FONT-SIZE: 18px\">";
        private const string Api_Detail_Id = "api_detail";
        private const string Resources_Id = "resources";
        private const string Span_TagName = "SPAN";
        private const string Div_TagName = "DIV";
        private const string B_TagName = "B";
        private const string Tr_TagName = "TR";
        private const string Tbody_TagName = "TBODY";
        private const string LoL_Library_Name = "RiotSharp";


        public LoLAutoGenerateFrm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoLDtoAutoGenerateProcess1();
        }

        private void LoLDtoAutoGenerateProcess1()
        {
            string dtoPath = txbDefaultDtoPath.Text.Trim();
            Dictionary<string, List<HtmlElement>> dics = new Dictionary<string, List<HtmlElement>>();

            if (!Directory.Exists(dtoPath))
            {
                Directory.CreateDirectory(dtoPath);
            }

            try
            {
                string html = System.IO.File.ReadAllText(@"D:\WangjqWork\MyTool\LoLMetroAT\LoLAutoGenerateTool\Riot Developer Portal.txt", Encoding.Unicode);

                CQ dom = html;

                CQ lstDivBold = dom["div"];

                Dictionary<LoLClass, List<LoLProperties>> lstClassNamesForApi = new Dictionary<LoLClass, List<LoLProperties>>();

                foreach (var divNode in lstDivBold.ToList())
                {
                    var divAttr = divNode.Attributes;

                    if (divAttr["class"] == "api_detail inner_content" && divAttr["loaded"] == "true")
                    {
                        lstClassNamesForApi.Clear();

                        string apiName = divNode.Attributes["api-name"];
                        string key = string.Empty;

                        string[] apiNames = apiName.Split('-');
                        foreach (string an in apiNames)
                        {
                            if (string.IsNullOrEmpty(key))
                            {
                                key = CodeGenerationHelper.MakeFirstCharUpperCase(an);
                            }
                            else
                            {
                                key += "_" + CodeGenerationHelper.MakeFirstCharUpperCase(an);
                            }
                        }

                        string keyPath = Path.Combine(dtoPath, key);

                        if (!Directory.Exists(keyPath))
                        {
                            Directory.CreateDirectory(keyPath);
                        }

                        CQ v3DivDom = divNode.OuterHTML;
                        CQ lstUlBold = v3DivDom["ul"];

                        foreach (var ulNode in lstUlBold.ToList())
                        {
                            var ulAttr = ulNode.Attributes;

                            if (ulAttr["id"] == "resources")
                            {
                                CQ v3UlDom = ulNode.OuterHTML;

                                CQ lstLiBold = v3UlDom["li"];

                                foreach (var liNode in lstLiBold.ToList())
                                {
                                    var liAttr = liNode.Attributes;

                                    if (liAttr["class"] == "get operation")
                                    {
                                        CQ v3LiDom = liNode.OuterHTML;

                                        CQ lstLiDivBold = v3LiDom["div"];

                                        foreach (var liDivNode in lstLiDivBold.ToList())
                                        {
                                            var liDivAttr = liDivNode.Attributes;

                                            if (liDivAttr["class"] == "content")
                                            {
                                                CQ v3LiDivDom = liDivNode.OuterHTML;
                                                CQ lstDetailDivBold = v3LiDivDom["div"];

                                                var lstLDDBS = lstDetailDivBold.Where(lDDB => lDDB.Attributes["class"] == "block response_body");

                                                string className = string.Empty;

                                                foreach (var lddb in lstLDDBS)
                                                {
                                                    CQ lddbDom = lddb.InnerHTML;

                                                    if (lddbDom["h4"].Length > 0)
                                                        continue;
                                                    else
                                                    {
                                                        if (lddbDom["h5"].Length > 0)
                                                        {
                                                            className = lddbDom["h5"][0].InnerText.Trim();
                                                            if (apiName.Contains("static"))
                                                            {
                                                                className = className + "Static";
                                                            }

                                                            LoLClass lc = new LoLClass();
                                                            lc.ClassName = className;
                                                            lc.ClassMemo = lddb.InnerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)[0].Replace(className, string.Empty).Trim();


                                                            if (lstClassNamesForApi.Keys.SingleOrDefault(lstLClass => lstLClass.ClassName == className) == null)
                                                            {
                                                                lstClassNamesForApi.Add(lc, new List<LoLProperties>());
                                                            }
                                                            else
                                                            {
                                                                lc = lstClassNamesForApi.Keys.SingleOrDefault(lstLClass => lstLClass.ClassName == className);
                                                            }

                                                            CQ trs = lddbDom["tbody"]["tr"];

                                                            foreach (var trNode in trs)
                                                            {
                                                                CQ tdDom = trNode.OuterHTML;
                                                                CQ tds = tdDom["td"];

                                                                if (tds.Length > 0)
                                                                {
                                                                    LoLProperties lp = new LoLProperties();

                                                                    lp.ProtyName = tds[0].InnerText.Trim();
                                                                    lp.ProtyType = tds[1].InnerText.Trim();
                                                                    lp.ProtyMemo = tds[2].InnerText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)[0].Replace(className, string.Empty).Trim();

                                                                    if (lstClassNamesForApi[lc].SingleOrDefault(lProty => lProty.ProtyName == lp.ProtyName) == null)
                                                                    {
                                                                        lstClassNamesForApi[lc].Add(lp);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }

                        string codeNamespace = string.Format("{0}.{1}", LoL_Library_Name, key);

                        //if (staticFlg)
                        //{
                        //    foreach (var lcnfKey in lstClassNamesForApi.Keys)
                        //    {
                        //        if (lp.ProtyType.Contains(lcnfKey.ClassName.Replace("Static", "")))
                        //        {
                        //            lp.ProtyType = lp.ProtyType.Replace(lcnfKey.ClassName.Replace("Static", ""), lcnfKey.ClassName);
                        //        }
                        //    }
                        //}
                        bool staticFlg = false;
                        foreach (LoLClass lstKey in lstClassNamesForApi.Keys)
                        {
                            staticFlg = false;
                            Sample sample = new Sample(codeNamespace, lstKey.ClassName, lstKey.ClassMemo); ;
                            string classPath = Path.Combine(keyPath, lstKey.ClassName + ".cs");

                            if (lstKey.ClassName.Contains("Static"))
                            {
                                staticFlg = true;
                            }
                            else
                            {
                                staticFlg = false;
                            }

                            if (lstKey.ClassName == "MasteryTreeListDtoStatic")
                            {

                            }

                            foreach (var lProperty in lstClassNamesForApi[lstKey])
                            {
                                if (staticFlg)
                                {
                                    foreach (LoLClass lstOrgKey in lstClassNamesForApi.Keys)
                                    {
                                        string orgClassName = lstOrgKey.ClassName.Replace("Static", "");

                                        if (lProperty.ProtyType.Contains(orgClassName))
                                        {
                                            string reProtyType = string.Empty;

                                            if (lProperty.ProtyType.Contains("List[") || lProperty.ProtyType.Contains("Map[") || lProperty.ProtyType.Contains("Set["))
                                            {
                                                reProtyType = lProperty.ProtyType.Replace("List[", "").Replace("Map[", "").Replace("Set[", "").Replace("]", "").Trim();

                                                if (reProtyType.Contains(','))
                                                {
                                                    int rIndex = reProtyType.IndexOf(',');
                                                    int orgIndex = reProtyType.IndexOf(orgClassName);

                                                    if (rIndex > orgIndex)
                                                    {
                                                        reProtyType = reProtyType.Substring(0, rIndex).Trim();
                                                    }
                                                    else
                                                    {
                                                        reProtyType = reProtyType.Substring(orgIndex).Trim();
                                                    }
                                                }


                                                if (reProtyType == orgClassName)
                                                {
                                                    lProperty.ProtyType = lProperty.ProtyType.Replace(reProtyType, lstOrgKey.ClassName);
                                                }
                                            }
                                            else
                                            {
                                                if (orgClassName == lProperty.ProtyType)
                                                {
                                                    lProperty.ProtyType = lProperty.ProtyType.Replace(orgClassName, lstOrgKey.ClassName);
                                                }
                                            }

                                            // string reProtyType = lProperty.ProtyType.Replace(orgClassName, lstOrgKey.ClassName);


                                            continue;
                                        }
                                    }
                                }

                                sample.AddFields(lProperty.ProtyName, lProperty.ProtyType, lProperty.ProtyMemo);
                                sample.AddProperties(lProperty.ProtyName, lProperty.ProtyType, lProperty.ProtyMemo);
                            }

                            sample.GenerateCSharpCode(classPath);
                        }
                    }
                }

                MessageBox.Show("Convert End !");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoLAutoGenerateFrm_Load(object sender, EventArgs e)
        {
            txbDefaultDtoPath.Text = Path.Combine(System.Windows.Forms.Application.StartupPath,
                LoL_Default_Dto_Folder);
        }

        private void LoLDtoAutoGenerateProcess()
        {
            string dtoPath = txbDefaultDtoPath.Text.Trim();
            Dictionary<string, List<HtmlElement>> dics = new Dictionary<string, List<HtmlElement>>();

            if (!Directory.Exists(dtoPath))
            {
                Directory.CreateDirectory(dtoPath);
            }

            try
            {
                HtmlElement hElements = webBrowser1.Document.GetElementById(Api_Detail_Id).Document.GetElementById(Resources_Id);

                foreach (HtmlElement curElement in hElements.Children)
                {
                    List<HtmlElement> list = new List<HtmlElement>();
                    string key = string.Empty;

                    HtmlElementCollection spanElements = curElement.GetElementsByTagName(Span_TagName);

                    foreach (HtmlElement spanElement in spanElements)
                    {
                        if (!string.IsNullOrEmpty(spanElement.OuterHtml) && spanElement.OuterHtml.Contains(Span_Rex))
                        {
                            key = spanElement.OuterText.Trim();

                            if (key.Contains("-") || key.Contains("."))
                            {
                                key = key.Replace("-", "_").Replace(".", "");
                            }

                            //key = spanElement.OuterText.Trim().Replace("-", "");
                            //key = key.Substring(0, key.Length - 4);
                        }
                    }

                    HtmlElementCollection chidElements = curElement.Children[1].GetElementsByTagName(Div_TagName);

                    foreach (HtmlElement chidCurElement in chidElements)
                    {
                        if (chidCurElement.OuterHtml.Length <= Div_Rex.Length)
                            continue;

                        if (!string.IsNullOrEmpty(chidCurElement.OuterHtml) && chidCurElement.OuterHtml.Substring(0, Div_Rex.Length).Equals(Div_Rex))
                        {
                            list.Add(chidCurElement);
                        }
                    }

                    if (dics.ContainsKey(key))
                    {
                        dics[key].AddRange(list);
                    }
                    else
                    {
                        dics.Add(key, list);
                    }
                }

                List<string> dtoNames = new List<string>();
                string oldKey = string.Empty;

                foreach (string key in dics.Keys)
                {
                    string keyPath = Path.Combine(dtoPath, CodeGenerationHelper.MakeFirstCharUpperCase(key));

                    if (!Directory.Exists(keyPath))
                    {
                        Directory.CreateDirectory(keyPath);
                    }

                    foreach (HtmlElement htmlVal in dics[key])
                    {
                        string className = htmlVal.GetElementsByTagName(B_TagName)[0].OuterText.Trim();

                        if (dtoNames.Contains(className))
                            continue;

                        string codeNamespace = string.Format("{0}.{1}", LoL_Library_Name, CodeGenerationHelper.MakeFirstCharUpperCase(key));
                        string classMemo = htmlVal.OuterText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)[0].Replace(className, string.Empty).TrimStart();
                        string classPath = Path.Combine(keyPath, className + ".cs");

                        Sample sample = new Sample(codeNamespace, className, classMemo);

                        HtmlElementCollection properts = htmlVal.GetElementsByTagName(Tbody_TagName)[0].GetElementsByTagName(Tr_TagName);

                        sample.AddFields(properts);
                        sample.AddProperties(properts);
                        //sample.AddMethod();
                        //sample.AddConstructor();
                        //sample.AddEntryPoint();

                        sample.GenerateCSharpCode(classPath);

                        dtoNames.Add(className);
                    }

                    dtoNames.Clear();
                }

                dtoNames = null;




                MessageBox.Show("Convert End !");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    /// <summary>
    /// This code example creates a graph using a CodeCompileUnit and  
    /// generates source code for the graph using the CSharpCodeProvider.
    /// </summary>
    class Sample
    {
        /// <summary>
        /// Define the compile unit to use for code generation. 
        /// </summary>
        CodeCompileUnit targetUnit;

        /// <summary>
        /// The only class in the compile unit. This class contains 2 fields,
        /// 3 properties, a constructor, an entry point, and 1 simple method. 
        /// </summary>
        CodeTypeDeclaration targetClass;

        /// <summary>
        /// Define the class.
        /// </summary>
        public Sample(string codeNamespace, string className, string classMemo)
        {
            targetUnit = new CodeCompileUnit();
            CodeNamespace samples = new CodeNamespace(codeNamespace);
            samples.Imports.Add(new CodeNamespaceImport("System"));
            samples.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            samples.Imports.Add(new CodeNamespaceImport("System.Linq"));
            samples.Imports.Add(new CodeNamespaceImport("System.Text"));
            samples.Imports.Add(new CodeNamespaceImport("System.Collections"));
            samples.Imports.Add(new CodeNamespaceImport("Newtonsoft.Json"));

            targetClass = new CodeTypeDeclaration(className);
            targetClass.IsClass = true;
            targetClass.TypeAttributes =
                TypeAttributes.Public;
            targetClass.Comments.Add(new CodeCommentStatement(
                classMemo));
            //targetClass.CustomAttributes = new CodeAttributeDeclarationCollection {
            //        new CodeAttributeDeclaration("DataContract")};
            samples.Types.Add(targetClass);
            targetUnit.Namespaces.Add(samples);
        }

        /// <summary>
        /// Adds two fields to the class.
        /// </summary>
        public void AddFields(HtmlElementCollection htmls)
        {
            foreach (HtmlElement html in htmls)
            {
                string fieldName = html.Children[0].OuterText.Trim();
                string fieldType = GetType(html.Children[1].OuterText.Trim());
                string fieldMemo = html.Children[2].OuterText;

                // Declare the widthValue field.
                CodeMemberField widthValueField = new CodeMemberField();

                widthValueField.Attributes = MemberAttributes.Private;
                widthValueField.CustomAttributes = new CodeAttributeDeclarationCollection {
                    new CodeAttributeDeclaration("JsonProperty", new CodeAttributeArgument(
                        new CodePrimitiveExpression(fieldName))) };

                widthValueField.Name = "_" + CodeGenerationHelper.MakeFirstCharLowerCase(fieldName);
                widthValueField.Type = new CodeTypeReference(fieldType);
                widthValueField.Comments.Add(new CodeCommentStatement(
                    fieldMemo));

                targetClass.Members.Add(widthValueField);
            }
        }

        /// <summary>
        /// Adds two fields to the class.
        /// </summary>
        public void AddFields(string fieldName, string fieldType, string fieldMemo)
        {
            // Declare the widthValue field.
            CodeMemberField widthValueField = new CodeMemberField();

            widthValueField.Attributes = MemberAttributes.Private;
            widthValueField.CustomAttributes = new CodeAttributeDeclarationCollection {
                    new CodeAttributeDeclaration("JsonProperty", new CodeAttributeArgument(
                        new CodePrimitiveExpression(fieldName))) };

            widthValueField.Name = "_" + CodeGenerationHelper.MakeFirstCharLowerCase(fieldName);
            widthValueField.Type = new CodeTypeReference(GetType(fieldType));
            widthValueField.Comments.Add(new CodeCommentStatement(
                fieldMemo));

            targetClass.Members.Add(widthValueField);
        }

        /// <summary>
        /// Add three properties to the class.
        /// </summary>
        public void AddProperties(string propertName, string propertType, string propertMemo)
        {
            string rePropertName = string.Empty;

            // Declare the read-only Width property.
            CodeMemberProperty widthProperty = new CodeMemberProperty();

            widthProperty.Attributes =
                MemberAttributes.Public | MemberAttributes.Final;

            if (propertName.Substring(0, 1).ToUpper() == propertName.Substring(0, 1))
            {
                rePropertName = CodeGenerationHelper.MakeFirstCharUpperCase(propertName);

                rePropertName = string.Format("ReName_{0}", rePropertName);

                widthProperty.Name = CodeGenerationHelper.MakeFirstCharUpperCase(rePropertName);
            }
            else
            {
                widthProperty.Name = CodeGenerationHelper.MakeFirstCharUpperCase(propertName);
            }


            widthProperty.HasGet = true;
            widthProperty.HasSet = true;
            widthProperty.Type = new CodeTypeReference(GetType(propertType));
            widthProperty.Comments.Add(new CodeCommentStatement(
                propertMemo));
            widthProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "_" + CodeGenerationHelper.MakeFirstCharLowerCase(propertName))));

            widthProperty.SetStatements.Add(new CodeAssignStatement(
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "_" + CodeGenerationHelper.MakeFirstCharLowerCase(propertName)), new CodePropertySetValueReferenceExpression()));


            targetClass.Members.Add(widthProperty);
        }


        private string GetType(string strType)
        {
            string fieldType = strType;

            if (fieldType.Contains("[") && fieldType.Contains("]"))
            {
                if (fieldType.Contains("Set["))
                {
                    fieldType = fieldType.Replace("Set[", "List[");
                }
                else if (fieldType.Contains("Map["))
                {
                    fieldType = fieldType.Replace("Map[", "System.Collections.Generic.Dictionary[");

                    if (fieldType.Contains("boolean"))
                    {
                        fieldType = fieldType.Replace("boolean", "System.Boolean");
                    }
                }

                fieldType = fieldType.Replace("[", "<");
                fieldType = fieldType.Replace("]", ">");
            }
            else
            {
                if (fieldType.Contains("long"))
                {
                    fieldType = "System.Int64";
                }
                else if (fieldType.Contains("string"))
                {
                    fieldType = "System.String";
                }
                else if (fieldType.Contains("int"))
                {
                    fieldType = "System.Int32";
                }
                else if (fieldType.Contains("double"))
                {
                    fieldType = "System.Double";
                }
                else if (fieldType.Contains("boolean"))
                {
                    fieldType = "System.Boolean";
                }
                else if (fieldType.Contains("object"))
                {
                    fieldType = "System.Object";
                }
            }

            return fieldType;
        }

        /// <summary>
        /// Add three properties to the class.
        /// </summary>
        public void AddProperties(HtmlElementCollection htmls)
        {
            foreach (HtmlElement html in htmls)
            {
                string rePropertName = string.Empty;
                string propertName = html.Children[0].OuterText.Trim();
                string propertType = GetType(html.Children[1].OuterText.Trim());
                string propertMemo = html.Children[2].OuterText;

                // Declare the read-only Width property.
                CodeMemberProperty widthProperty = new CodeMemberProperty();

                widthProperty.Attributes =
                    MemberAttributes.Public | MemberAttributes.Final;

                if (propertName.Substring(0, 1).ToUpper() == propertName.Substring(0, 1))
                {
                    rePropertName = CodeGenerationHelper.MakeFirstCharUpperCase(propertName);

                    rePropertName = string.Format("ReName_{0}", rePropertName);

                    widthProperty.Name = CodeGenerationHelper.MakeFirstCharUpperCase(rePropertName);
                }
                else
                {
                    widthProperty.Name = CodeGenerationHelper.MakeFirstCharUpperCase(propertName);
                }


                widthProperty.HasGet = true;
                widthProperty.HasSet = true;
                widthProperty.Type = new CodeTypeReference(propertType);
                widthProperty.Comments.Add(new CodeCommentStatement(
                    propertMemo));
                widthProperty.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), "_" + CodeGenerationHelper.MakeFirstCharLowerCase(propertName))));

                widthProperty.SetStatements.Add(new CodeAssignStatement(
                    new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), "_" + CodeGenerationHelper.MakeFirstCharLowerCase(propertName)), new CodePropertySetValueReferenceExpression()));


                targetClass.Members.Add(widthProperty);
            }
        }

        /// <summary>
        /// Adds a method to the class. This method multiplies values stored 
        /// in both fields.
        /// </summary>
        public void AddMethod()
        {
            // Declaring a ToString method
            CodeMemberMethod toStringMethod = new CodeMemberMethod();
            toStringMethod.Attributes =
                MemberAttributes.Public | MemberAttributes.Override;
            toStringMethod.Name = "ToString";
            toStringMethod.ReturnType =
                new CodeTypeReference(typeof(System.String));

            CodeFieldReferenceExpression widthReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "Width");
            CodeFieldReferenceExpression heightReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "Height");
            CodeFieldReferenceExpression areaReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "Area");

            // Declaring a return statement for method ToString.
            CodeMethodReturnStatement returnStatement =
                new CodeMethodReturnStatement();

            // This statement returns a string representation of the width,
            // height, and area.
            string formattedOutput = "The object:" + Environment.NewLine +
                " width = {0}," + Environment.NewLine +
                " height = {1}," + Environment.NewLine +
                " area = {2}";
            returnStatement.Expression =
                new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.String"), "Format",
                new CodePrimitiveExpression(formattedOutput),
                widthReference, heightReference, areaReference);
            toStringMethod.Statements.Add(returnStatement);
            targetClass.Members.Add(toStringMethod);
        }
        /// <summary>
        /// Add a constructor to the class.
        /// </summary>
        public void AddConstructor()
        {
            // Declare the constructor
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes =
                MemberAttributes.Public | MemberAttributes.Final;

            // Add parameters.
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(
                typeof(System.Double), "width"));
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(
                typeof(System.Double), "height"));

            // Add field initialization logic
            CodeFieldReferenceExpression widthReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "widthValue");
            constructor.Statements.Add(new CodeAssignStatement(widthReference,
                new CodeArgumentReferenceExpression("width")));
            CodeFieldReferenceExpression heightReference =
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), "heightValue");
            constructor.Statements.Add(new CodeAssignStatement(heightReference,
                new CodeArgumentReferenceExpression("height")));
            targetClass.Members.Add(constructor);
        }

        /// <summary>
        /// Add an entry point to the class.
        /// </summary>
        public void AddEntryPoint()
        {
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeObjectCreateExpression objectCreate =
                new CodeObjectCreateExpression(
                new CodeTypeReference("CodeDOMCreatedClass"),
                new CodePrimitiveExpression(5.3),
                new CodePrimitiveExpression(6.9));

            // Add the statement:
            // "CodeDOMCreatedClass testClass = 
            //     new CodeDOMCreatedClass(5.3, 6.9);"
            start.Statements.Add(new CodeVariableDeclarationStatement(
                new CodeTypeReference("CodeDOMCreatedClass"), "testClass",
                objectCreate));

            // Creat the expression:
            // "testClass.ToString()"
            CodeMethodInvokeExpression toStringInvoke =
                new CodeMethodInvokeExpression(
                new CodeVariableReferenceExpression("testClass"), "ToString");

            // Add a System.Console.WriteLine statement with the previous 
            // expression as a parameter.
            start.Statements.Add(new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine", toStringInvoke));
            targetClass.Members.Add(start);
        }
        /// <summary>
        /// Generate CSharp source code from the compile unit.
        /// </summary>
        /// <param name="filename">Output file name</param>
        public void GenerateCSharpCode(string fileName)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter(fileName))
            {
                provider.GenerateCodeFromCompileUnit(
                    targetUnit, sourceWriter, options);
            }
        }

        ///// <summary>
        ///// Create the CodeDOM graph and generate the code.
        ///// </summary>
        //static void Main()
        //{
        //    Sample sample = new Sample();
        //    sample.AddFields();
        //    sample.AddProperties();
        //    sample.AddMethod();
        //    sample.AddConstructor();
        //    sample.AddEntryPoint();
        //    sample.GenerateCSharpCode(outputFileName);
        //}
    }
}
