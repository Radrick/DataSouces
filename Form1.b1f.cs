using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;
using StudyDataSource.Model;

namespace StudyDataSource
{
    [FormAttribute("StudyDataSource.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        Client client = new Client();
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Grid Grid2;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.ComboBox ComboBox0;

        public Form1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_0").Specific));
            this.EditText0.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.EditText0_ChooseFromListBefore);
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_8").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_16").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_17").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.Button1.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button1_PressedAfter);
            this.Grid2 = ((SAPbouiCOM.Grid)(this.GetItem("Item_21").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_23").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_25").Specific));
            this.Button2.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button2_PressedAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_26").Specific));
            this.Button3.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button3_PressedAfter);
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_27").Specific));
            this.Button4.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button4_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {}
        
        private void OnCustomInitialize()
        {
            LoadComboBoxCardType();
        }

        /*
         * Filtra o CardType do Cliente no ChooseFromList
         */
        private void EditText0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.ISBOChooseFromListEventArg oCFLEvent = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            SAPbouiCOM.Conditions pConditions = new SAPbouiCOM.Conditions();
            SAPbouiCOM.Condition condition = pConditions.Add();

            try
            {
                condition.Alias = "CardType";
                condition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                condition.CondVal = "C";

                this.UIAPIRawForm.ChooseFromLists.Item("CFL_0").SetConditions(pConditions);
            }
            catch (Exception e)
            {
                Application.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        /*
         * Aplica o ChooseFromList ao campo
         */
        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ISBOChooseFromListEventArg oCFLEvent = ((SAPbouiCOM.ISBOChooseFromListEventArg)pVal);
            SAPbouiCOM.DataTable oDataTable = null;

            try
            {
                oDataTable = oCFLEvent.SelectedObjects;

                if (oDataTable == null)
                    return;

                /*
                 * O GetValue pode ser utilizado com o índice da coluna (0,0) ou com o nome do item ("CardFName", 0) 
                 * Aplica as propriedades do clientes os valores capturados no Choose From List
                 */
                client.CodClient = oDataTable.GetValue(0, 0).ToString();
                client.Name = oDataTable.GetValue(1, 0).ToString();
                client.fName = oDataTable.GetValue("CardFName", 0).ToString();
                client.ClientGroup = oDataTable.GetValue("GroupCode", 0).ToString();
                client.DataInicioRelacao = oDataTable.GetValue("DateFrom", 0);
                client.CardType = oDataTable.GetValue("CardType", 0).ToString();

                /* Percorrendo um Data table
                for (int i = 0; i < oDataTable.Rows.Count; i++)
                {
                    for (int y = 0; y < oDataTable.Columns.Count; y++)
                    {
                        Console.Write(oDataTable.GetValue(y, i));
                    }   
                }*/

                /*
                 * Verifica se a propriedade do código do cliente foi setada e aplica os valores capturados no Cliente nos campos através do UserDataSource.
                 * Caso contrário, não foi selecionado nenhuma opção
                 */
                if (!String.IsNullOrEmpty(client.CodClient))
                {
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("CodClient").ValueEx = client.CodClient;
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("NameClient").ValueEx = client.Name;
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("fName").ValueEx = client.Name;
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("ClientGoup").ValueEx = client.ClientGroup;

                    switch (client.CardType)
                    {
                        case ("C"):
                            this.UIAPIRawForm.DataSources.UserDataSources.Item("TypeClient").ValueEx = SAPbobsCOM.BoCardTypes.cCustomer.ToString();
                            break;
                        case ("S"):
                            this.UIAPIRawForm.DataSources.UserDataSources.Item("TypeClient").ValueEx = SAPbobsCOM.BoCardTypes.cSupplier.ToString();
                            break;
                        default:
                            this.UIAPIRawForm.DataSources.UserDataSources.Item("TypeClient").ValueEx = SAPbobsCOM.BoCardTypes.cLid.ToString();
                            break;
                    }

                    //this.UIAPIRawForm.DataSources.UserDataSources.Item("CardType").ValueEx = client.CardType;
                    //this.UIAPIRawForm.DataSources.UserDataSources.Item("dtIniRela").ValueEx = client.DataInicioRelacao.ToString().Substring(0,10);
                }
            }
            catch (Exception e)
            {
                Application.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            try
            {
                if (client.ClientGroup != null)
                {
                    /*
                     * Capturando valor do data table e atribuindo ao UserDataSource
                     */
                    this.UIAPIRawForm.DataSources.DataTables.Item("DT_0").ExecuteQuery("SELECT GroupName FROM OCRG WHERE GroupCode='" + client.ClientGroup + "'");
                    client.NameClientGroup = this.UIAPIRawForm.DataSources.DataTables.Item("DT_0").GetValue("GroupName", 0).ToString();
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("nameGoupPN").ValueEx = client.NameClientGroup;
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText("Código do cliente vazio", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                }
            }
            catch (Exception e)
            {
                Application.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void Button1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (client.CodClient != null)
                {
                    this.UIAPIRawForm.DataSources.DataTables.Item("DT_0").ExecuteQuery(@"SELECT DocNum,CardCode, CardName FROM ORDR WHERE CardCode ='" + client.CodClient + "'");

                    /* Bind de DataTable com Matrix é necessário utilizar o método Bind*/
                    Matrix0.Columns.Item("Col_0").DataBind.Bind("DT_0", "DocNum");
                    Matrix0.Columns.Item("Col_1").DataBind.Bind("DT_0", "CardCode");
                    Matrix0.Columns.Item("Col_2").DataBind.Bind("DT_0", "CardName");

                    Matrix0.LoadFromDataSource();
                    Matrix0.AutoResizeColumns();
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText("Código do cliente vazio", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                }
            }
            catch (Exception e)
            {
                Application.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void LoadComboBoxCardType()
        {
            ComboBox0.ValidValues.Add(SAPbobsCOM.BoCardTypes.cCustomer.ToString(), "Cliente");
            ComboBox0.ValidValues.Add(SAPbobsCOM.BoCardTypes.cSupplier.ToString(), "Fornecedor");
            ComboBox0.ValidValues.Add(SAPbobsCOM.BoCardTypes.cLid.ToString(), "Cliente potencial");
        }

        #region Bind com Grid

        /*O Grid possui na sua definição o DataTable. Dessa forma, o Grid se adequa a query que for executada no DataTable*/
        private void Button2_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (client.CodClient != null)
                {
                    this.UIAPIRawForm.DataSources.DataTables.Item("DT_1").ExecuteQuery(@"SELECT CardCode as ""Codigo do cliente"", CardName as ""Nome do cliente"" FROM OCRD WHERE CardCode ='" + client.CodClient + "'");
                } else
                {
                    Application.SBO_Application.StatusBar.SetText("Código do cliente vazio", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                }
            }
            catch (Exception e)
            {
                Application.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        private void Button3_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                this.UIAPIRawForm.DataSources.DataTables.Item("DT_1").ExecuteQuery(@"SELECT ""ItemCode"", ""ItemName"" FROM OITM");
            }
            catch (Exception e)
            {
                Application.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void Button4_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                this.UIAPIRawForm.DataSources.DataTables.Item("DT_1").ExecuteQuery(@"SELECT ""DocNum"", ""CardCode"", ""CardName"" FROM ORDR");
            }
            catch (Exception e)
            {
                Application.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        #endregion
    }
}