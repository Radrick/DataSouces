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
        private SAPbouiCOM.EditText EditText4;
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
        private SAPbouiCOM.Button Button0;

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
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
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
            this.OnCustomInitialize();
        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {}
        
        private void OnCustomInitialize()
        {}

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
                client.ClientType = oDataTable.GetValue("CardType", 0).ToString();
                client.DataInicioRelacao = oDataTable.GetValue("DateFrom", 0);

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
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("ClientType").ValueEx = client.ClientType;
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
                    this.UIAPIRawForm.DataSources.DataTables.Item("DT_0").ExecuteQuery("SELECT GroupName FROM OCRG WHERE GroupCode='"+client.ClientGroup+"'");
                    client.NameClientGroup = this.UIAPIRawForm.DataSources.DataTables.Item("DT_0").GetValue("GroupName", 0).ToString();
                    this.UIAPIRawForm.DataSources.UserDataSources.Item("nameGoupPN").ValueEx = client.NameClientGroup;
                }
            }
            catch (Exception e)
            {
                Application.SBO_Application.StatusBar.SetText(e.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
    }
}