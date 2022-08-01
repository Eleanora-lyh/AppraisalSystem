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
        key: "PatientName",
        label: "病人名称"
    },
    {
        key: "IdNumber",
        label: "病人身份证号"
    },
    {
        key: "Gender",
        label: "病人性别"
    },
    {
        key: "status",
        label: "病人状态"
    },
    {
        key: "Birthday",
        label: "病人出生日期"
    },
    {
        key: "CityName_view",
        label: "籍贯"
    },
    {
        key: "HostpitalName_view",
        label: "所属医院"
    },
    {
        key: "PhotoId",
        label: "照片",
        isSlot: true 
    },
    {
        key: "VirusName_view",
        label: "病毒"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const GenderTypes: Array<any> = [
  { Text: "男", Value: "Male" },
  { Text: "女", Value: "Female" }
];
export const statusTypes: Array<any> = [
  { Text: "无症状", Value: "asymptomatic" },
  { Text: "疑似", Value: "suspected" },
  { Text: "确诊", Value: "confirmed" },
  { Text: "治愈", Value: "cured" },
  { Text: "死亡", Value: "dead" }
];

