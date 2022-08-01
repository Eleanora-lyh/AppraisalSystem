import i18n from "@/lang";

export const ASSEMBLIES: Array<string> = [
  "add",
  "edit",
  "delete",
  "export",
  "imported"
];

export const TABLE_HEADER: Array<object> = [


    {
        key: "VirusName",
        label: "病毒名称"
    },
    {
        key: "VirusCode",
        label: "病毒代码"
    },
    {
        key: "VirusRemark",
        label: "病毒描述"
    },
    {
        key: "VirusType",
        label: "病毒种类"
    },
    {
        key: "PatientName_view",
        label: "患者"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const VirusTypeTypes: Array<any> = [
  { Text: "RNA", Value: "RNA" },
  { Text: "DNA", Value: "DNA" }
];

