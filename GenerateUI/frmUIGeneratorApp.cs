using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateUI
{
    public partial class frmUIGeneratorApp : Form
    {
        public List<ModelProperty> _modelProperties { get; set; }
        public frmUIGeneratorApp()
        {
            InitializeComponent();
            _modelProperties = new List<ModelProperty>();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int counter = 1;

            foreach (DataGridViewRow row in dgvUIModel.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                ModelProperty modelProperty = new ModelProperty
                {
                    OrderId = counter,
                    FilePath = txtFilePath.Text,
                    ModelName = txtModelName.Text,
                    ModelDataType = CheckValidInput(row, "ModelDataType"), //row.Cells["ModelDataType"].Value.ToString(),
                    ModelPropertyName = CheckValidInput(row, "ModelPropertyName"), //row.Cells["ModelPropertyName"].Value.ToString(),
                    UIType = CheckValidInput(row, "UIType"),
                    DdlDisplayText = CheckValidInput(row, "DdlDisplayText"),                    
                    DdlDisplayValue = CheckValidInput(row, "DdlDisplayValue"),                    
                    DisplayLabel = CheckValidInput(row, "DisplayLabel")//row.Cells["DisplayLabel"].Value.ToString()
                };
                counter++;

                _modelProperties.Add(modelProperty);

            }

            var firstItem = _modelProperties.First();

            GenerateModel(firstItem.FilePath + "\\" + firstItem.ModelName + ".ts");
            GenerateHTML(firstItem.FilePath + "\\" + firstItem.ModelName + ".html");
            GenerateComponent(firstItem.FilePath + "\\" + firstItem.ModelName + "Component.ts");
            GenerateService(firstItem.FilePath + "\\" + firstItem.ModelName + "Service.ts");


        }

        private string CheckValidInput(DataGridViewRow row,string columnKey)
        {
            return row.Cells[columnKey].Value==null?string.Empty: row.Cells[columnKey].Value.ToString();
        }

        private void GenerateService(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    MessageBox.Show("Check file already exists");
                    return;
                }

                // Create a new file     
                using (var sw = File.CreateText(fileName))
                {
                    var firstItem = _modelProperties.First();

                    sw.WriteLine("import { Injectable } from '@angular/core';");
                    sw.WriteLine("import { HttpClient } from '@angular/common/http';");
                    sw.WriteLine("import { HttpService } from 'src/app/core/services/http.service';");
                    sw.WriteLine("import DataService from 'src/app/shared/services/data.service';");
                    sw.WriteLine("import { environment } from 'src/environments/environment';");
                    sw.WriteLine("@Injectable({");
                    sw.WriteLine("  providedIn: 'root'");
                    sw.WriteLine("})");
                    sw.WriteLine("export class "+ firstItem.ModelName+ "Service extends DataService {");
                    sw.WriteLine("  constructor(http: HttpClient, httpService: HttpService) {");
                    sw.WriteLine("    const baseUrl = environment.baseUrl;");
                    sw.WriteLine("    super(http, `${baseUrl}/" + firstItem.ModelName + "`, httpService);");
                    sw.WriteLine("  }");
                    sw.WriteLine("}");

                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }

        private void GenerateComponent(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    MessageBox.Show("Check file already exists");
                    return;
                }

                var firstItem = _modelProperties.FirstOrDefault();

                // Create a new file     
                using (var sw = File.CreateText(fileName))
                {
                    sw.WriteLine("import { Component, OnInit } from '@angular/core';");
                    sw.WriteLine("import { FormGroup, FormBuilder, Validators } from '@angular/forms';");
                    sw.WriteLine("import { MessageService } from 'primeng/api';");
                    sw.WriteLine("import { NotificationComponent } from 'src/app/shared/components/notification/notification.component';");
                    sw.WriteLine("import { DatePipe } from '@angular/common';");
                    sw.WriteLine("");
                    sw.WriteLine("import { "+firstItem.ModelName+" } from '../../models/base-control.model';");
                    sw.WriteLine("import { " + firstItem.ModelName + "Service } from '../../services/base-control/base-control.service';");
                    sw.WriteLine("");
                    sw.WriteLine("@Component({");
                    sw.WriteLine("  selector: 'app-base-control',");
                    sw.WriteLine("  templateUrl: './base-control.component.html',");
                    sw.WriteLine("  styleUrls: ['./base-control.component.scss'],");
                    sw.WriteLine("  providers: [DatePipe]");
                    sw.WriteLine("})");
                    sw.WriteLine("export class " + firstItem.ModelName + "Component implements OnInit {");
                    sw.WriteLine("");
                    sw.WriteLine("  title = '" + AddSpacesToSentence(firstItem.ModelName,false) + "';");//work
                    sw.WriteLine("  formControl: FormGroup;");
                    sw.WriteLine("  values: " + firstItem.ModelName + "[];");
                    sw.WriteLine("  popup: boolean;");
                    sw.WriteLine("  status: string;");
                    sw.WriteLine("  cols: any[];");
                    sw.WriteLine("  notification: any;");
                    sw.WriteLine("");
                    sw.WriteLine("  constructor(");
                    sw.WriteLine("    private fb: FormBuilder,");
                    sw.WriteLine("    private messageService: MessageService,");
                    sw.WriteLine("    private service: "+firstItem.ModelName+ "Service,");
                    sw.WriteLine("    private date: DatePipe,");
                    sw.WriteLine("  ) {");
                    sw.WriteLine("    this.notification = new NotificationComponent(messageService);");
                    sw.WriteLine("  }");
                    sw.WriteLine("");
                    sw.WriteLine("  ngOnInit() {");
                    sw.WriteLine("    this.popup = false;");
                    sw.WriteLine("    this.getValue('getAll');");
                    sw.WriteLine("    this.formControl = this.fb.group({");
                    sw.WriteLine("      id: null,");
                    foreach (var item in _modelProperties)
                    {
                        sw.WriteLine("      "+item.ModelPropertyName+": ['', Validators.required],");
                    }

                    
                    //sw.WriteLine("      textBoxNumber: ['', Validators.required],");
                    //sw.WriteLine("      dropdown: ['', Validators.required],");
                    //sw.WriteLine("      checkbox: ['', Validators.required],");
                    //sw.WriteLine("      radiobutton: ['', Validators.required],");
                    //sw.WriteLine("      dateTimePicker: ['', Validators.required],");
                    //sw.WriteLine("      isActive: ['', Validators.required],");
                    //sw.WriteLine("      isDefault: ['', Validators.required],");
                    sw.WriteLine("    });");
                    sw.WriteLine("    this.cols = [");

                    foreach (var item in _modelProperties)
                    {
                        sw.WriteLine("      { field: '"+item.ModelPropertyName+"', header: '"+item.DisplayLabel+"' },");
                    }

                    
                    //sw.WriteLine("      { field: 'textBoxNumber', header: 'number' },");
                    //sw.WriteLine("      { field: 'dropdown', header: 'dropdown' },");
                    //sw.WriteLine("      { field: 'checkbox', header: 'checkbox' },");
                    //sw.WriteLine("      { field: 'radiobutton', header: 'radiobutton' },");
                    //sw.WriteLine("      { field: 'dateTimePicker', header: 'dateTimePicker', type: this.date, arg1: 'dd/MM/yyyy' },");
                    sw.WriteLine("    ];");
                    sw.WriteLine("  }");
                    sw.WriteLine("");
                    sw.WriteLine("  getValue(getAll: string) {");
                    sw.WriteLine("    this.service.getAll(getAll).subscribe(res =>");
                    sw.WriteLine("      this.values = res.result.items");
                    sw.WriteLine("    );");
                    sw.WriteLine("  }");
                    sw.WriteLine("");
                    sw.WriteLine("  onSubmit() {");
                    sw.WriteLine("    const data = this.formControl.value;");
                    sw.WriteLine("    if (this.formControl.valid) {");
                    sw.WriteLine("      if (this.formControl.get('id').value == null) {");
                    sw.WriteLine("        delete data.id;");
                    sw.WriteLine("        this.service.create(data, 'create').subscribe(res => {");
                    sw.WriteLine("          this.values.push(res.result);");
                    sw.WriteLine("          this.notification.showSuccess('Created Successfully', `${this.title} Created successfully`);");
                    sw.WriteLine("        },");
                    sw.WriteLine("          () => this.notification.showError('Something went wrong', 'Try Again')");
                    sw.WriteLine("        );");
                    sw.WriteLine("      } else {");
                    sw.WriteLine("        this.service.update(data, 'update').subscribe(res => {");
                    sw.WriteLine("          const id = res.result.id;");
                    sw.WriteLine("          const index = this.values.findIndex(x => x.id === id);");
                    sw.WriteLine("          this.values[index] = res.result;");
                    sw.WriteLine("          this.notification.showSuccess('Updated Successfully', `${this.title} Updated successfully`);");
                    sw.WriteLine("        });");
                    sw.WriteLine("      }");
                    sw.WriteLine("      this.formControl.reset();");
                    sw.WriteLine("      this.popup = false;");
                    sw.WriteLine("    }");
                    sw.WriteLine("  }");
                    sw.WriteLine("");
                    sw.WriteLine("  onEdit(data: "+firstItem.ModelName+") {");
                    sw.WriteLine("    this.popup = true;");
                    sw.WriteLine("    this.status = 'Update';");

                    foreach (var item in _modelProperties.Where(p=>p.UIType=="date"))
                    {
                        sw.WriteLine("    const "+ ToLowerFirstChar(item.ModelPropertyName) + " = new Date(data."+item.ModelPropertyName+");");
                        sw.WriteLine("    this.formControl.get('"+ ToLowerFirstChar(item.ModelPropertyName) + "').setValue("+ ToLowerFirstChar(item.ModelPropertyName) + ");");
                    }

                    
                    sw.WriteLine("    this.formControl.patchValue(data);");
                    sw.WriteLine("  }");
                    sw.WriteLine("");
                    sw.WriteLine("  onDelete(data: " + firstItem.ModelName + ") {//change");
                    sw.WriteLine("    this.values = this.values.filter(h => h !== data);");
                    sw.WriteLine("    this.service.delete(data.id, 'delete').subscribe(() =>");
                    sw.WriteLine("      this.notification.showSuccess('Deleted Successfully', `${this.title} Deleted successfully`)");
                    sw.WriteLine("    );");
                    sw.WriteLine("  }");
                    sw.WriteLine("}");



                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        string AddSpacesToSentence(string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        public string ToLowerFirstChar(string input)
        {
            string newString = input;
            if (!String.IsNullOrEmpty(newString) && Char.IsUpper(newString[0]))
                newString = Char.ToLower(newString[0]) + newString.Substring(1);
            return newString;
        }

        private void GenerateModel(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    MessageBox.Show("Check file already exists");
                    return;
                }

                // Create a new file     
                using (var sw = File.CreateText(fileName))
                {
                    sw.WriteLine("export interface " + _modelProperties.First().ModelName + " {");
                    sw.WriteLine("id: [null];");
                    foreach (var item in _modelProperties)
                    {
                        sw.WriteLine("" + item.ModelPropertyName + ": " + item.ModelDataType + ";");

                    }
                    sw.WriteLine("}");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private void GenerateHTML(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    MessageBox.Show("Check file already exists");
                    return;
                }

                // Create a new file     
                using (var sw = File.CreateText(fileName))
                {
                    GenerateBaseHtmlTable(sw);
                    Generatetable(sw);


                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private void Generatetable(StreamWriter sw)
        {
            sw.WriteLine("<p-dialog [(visible)]=\"popup\" modal=\"true\" [responsive]=\"true\" [style]=\"{width: '60%'}\" [minY]=\"70\"");
            sw.WriteLine("  [maximizable]=\"true\" [baseZIndex]=\"10000\">");
            sw.WriteLine("  <p-header>{{status}} {{title}}</p-header>");
            sw.WriteLine("  <form [formGroup]=\"formControl\" (ngSubmit)=\"onSubmit()\" class=\"container\">");
            sw.WriteLine("    <div class=\"row\">");
            sw.WriteLine("    <input type=\"text\" formControlName=\"id\" hidden>");
            sw.WriteLine("");

            var totalItems = _modelProperties.Count();
            var setDiv = "6";
            if (totalItems>6)
            {
                setDiv = "4";
            }
            

            foreach (var item in _modelProperties)
            {
                sw.WriteLine("<div class=\"form-group col-md-" + setDiv + "\">");
                //textbox,password,date
                if (item.UIType== "checkbox")
                {                    
                    sw.WriteLine("  <div class=\"custom-control custom-switch\">");
                    sw.WriteLine("    <input type=\""+ item.UIType + "\" class=\"custom-control-input\" id=\""+ item.ModelPropertyName + "\" formControlName=\""+item.ModelPropertyName+"\">");
                    sw.WriteLine("    <label class=\"custom-control-label\" for=\""+ item.ModelPropertyName + "\"><b>"+ item.DisplayLabel + "</b></label>");
                    sw.WriteLine("  </div>");                    
                }

                if (item.UIType == "text"|| item.UIType == "password"||item.UIType== "date" ||item.UIType == "number")
                {
                    sw.WriteLine("  <label for=\"" + item.ModelPropertyName + "\">" + item.DisplayLabel + "</label>");
                    sw.WriteLine("  <input id = \"" + item.ModelPropertyName + "\" type= \"" + item.UIType + "\" formControlName= \"" + item.ModelPropertyName + "\" class=\"form-control\" placeholder=\"Fill " + item.ModelPropertyName + "\">");
                }
                if(item.UIType== "radio")
                {
                    sw.WriteLine("<label>"+item.DisplayLabel+"</label>");
                    sw.WriteLine("   <div class=\"custom-control custom-radio\">");
                    sw.WriteLine("     <input type=\"radio\" class=\"custom-control-input\" value=\"true\" formControlName=\"" + item.ModelPropertyName + "\">");
                    sw.WriteLine("     <label class=\"custom-control-label\" for=\""+item.ModelPropertyName+"\">" + item.DisplayLabel +"</label>");
                    sw.WriteLine("   </div> ");
                    sw.WriteLine("   <div class=\"custom-control custom-radiox  \">");
                    sw.WriteLine("     <input type=\"radio\" class=\"custom-control-input\" value=\"false\" formControlName=\"" + item.ModelPropertyName + "\">");
                    sw.WriteLine("     <label class=\"custom-control-label\" for=\"" + item.ModelPropertyName + "\">" + item.DisplayLabel + "</label>");
                    sw.WriteLine("   </div> ");
                }

                if(item.UIType== "dropdown")
                {
                    sw.WriteLine("<label for=\""+item.ModelPropertyName+"\">"+item.DisplayLabel+"</label>");
                    sw.WriteLine("     <select class=\"form-control\" name=\""+ item.ModelPropertyName + "\"  formControlName=\""+item.DdlDisplayValue + "\">");
                    sw.WriteLine("<option *ngFor=\"let item of values\" value=\"{{ item."+item.DdlDisplayText+ " }}\">");
                    sw.WriteLine("{{ item."+item.DdlDisplayText+" }}");
                    sw.WriteLine("</option>");
                    sw.WriteLine("     </select>");
                }                   

                sw.WriteLine("</div>");
              
            }

            




            sw.WriteLine("    ");
            sw.WriteLine("  </div>");
            sw.WriteLine("  </form>");
            sw.WriteLine("  <p-footer>");
            sw.WriteLine("    <button type=\"button\" pButton icon=\"pi pi-plus\" (click)=\"onSubmit()\" [disabled]=\"!formControl.valid\"");
            sw.WriteLine("      label=\" {{status}} {{title}}\"></button>");
            sw.WriteLine("    <button class=\"ui-button-danger\" type=\"button\" pButton icon=\"pi pi-times\" label=\"Close\"");
            sw.WriteLine("      (click)=\"popup=false\"></button>");
            sw.WriteLine("  </p-footer>");
            sw.WriteLine("</p-dialog>");

        }

        private void GenerateBaseHtmlTable(StreamWriter sw)
        {
            sw.WriteLine("<p-table [columns]=\"cols\" [value]=\"values\" [paginator]=\"true\" [rows]=\"5\">");
            sw.WriteLine("  <ng-template pTemplate=\"caption\">");
            sw.WriteLine("    <div class=\"row\">");
            sw.WriteLine("      <div class=\"col-md-6\">");
            sw.WriteLine("        <div class=\"float-left\">");
            sw.WriteLine("          <h4>{{title}}</h4>");
            sw.WriteLine("        </div>");
            sw.WriteLine("      </div>");
            sw.WriteLine("      <div class=\"col-md-6\">");
            sw.WriteLine("        <button class=\"float-right\" type=\"button\" pButton icon=\"pi pi-plus\" (click)=\"popup=true; status='Add'\"");
            sw.WriteLine("          label=\"Add\"></button>");
            sw.WriteLine("      </div>");
            sw.WriteLine("    </div>");
            sw.WriteLine("  </ng-template>");
            sw.WriteLine("  <ng-template pTemplate=\"header\" let-columns>");
            sw.WriteLine("    <tr>");
            sw.WriteLine("      <th *ngFor=\"let col of columns\" [pSortableColumn]=\"col.field\">");
            sw.WriteLine("        {{col.header}}");
            sw.WriteLine("        <p-sortIcon [field]=\"col.field\"></p-sortIcon>");
            sw.WriteLine("      </th>");
            sw.WriteLine("      <th>Actions</th>");
            sw.WriteLine("    </tr>");
            sw.WriteLine("  </ng-template>");
            sw.WriteLine("  <ng-template pTemplate=\"body\" let-rowData let-columns=\"columns\">");
            sw.WriteLine("    <tr>");
            sw.WriteLine("      <td *ngFor=\"let col of columns\">");
            sw.WriteLine("        {{ col.type ? col.type.transform(rowData[col.field], col.arg1, col.arg2, col.arg3) : rowData[col.field] }}");
            sw.WriteLine("      </td>");
            sw.WriteLine("      <td class=\"ml-auto\">");
            sw.WriteLine("        <div class=\"d-flex flex-row justify-content-center\">");
            sw.WriteLine("          <button pButton type=\"button\" icon=\"pi pi-pencil\" class=\"ui-button-info ui-button-rounded ui-button-raised\"");
            sw.WriteLine("            style=\"margin-right: .5em\" (click)=\"onEdit(rowData)\"></button>");
            sw.WriteLine("          <button pButton type=\"button\" icon=\"pi pi-times\" class=\"ui-button-danger ui-button-rounded ui-button-raised\"");
            sw.WriteLine("            (click)=\"this.notification.showConfirm();\"></button>");
            sw.WriteLine("          <app-notification (confirmed)=\"onDelete(rowData)\"></app-notification>");
            sw.WriteLine("        </div>");
            sw.WriteLine("      </td>");
            sw.WriteLine("    </tr>");
            sw.WriteLine("  </ng-template>");
            sw.WriteLine("</p-table>");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = string.Empty;
            txtModelName.Text = string.Empty;
            dgvUIModel.Rows.Clear();
            dgvUIModel.Refresh();
        }

        private void dgvUIModel_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                switch (e.ColumnIndex.ToString())
                {
                    case "0":
                    case "2":
                        dgvUIModel.Cursor = Cursors.Hand;
                        break;

                    default: dgvUIModel.Cursor = Cursors.Default; break;
                }
            }
        }
    }

    public class ModelProperty
    {
        public int OrderId { get; set; }
        public string FilePath { get; set; }
        public string ModelName { get; set; }
        public string ModelDataType { get; set; }
        public string ModelPropertyName { get; set; }
        public string UIType { get; set; }
        public string DdlDisplayText { get; set; }
        public string DdlDisplayValue { get; set; }
        public string DisplayLabel { get; set; }
    }
}
