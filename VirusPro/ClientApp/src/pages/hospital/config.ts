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
        key: "HostpitalName",
        label: "医院名称"
    },
    {
        key: "HostpitalLevel",
        label: "医院级别"
    },
    {
        key: "CityName_view",
        label: "医院地点"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const HostpitalLevelTypes: Array<any> = [
  { Text: "一级医院", Value: "Class1" },
  { Text: "二级医院", Value: "Class2" },
  { Text: "三级医院", Value: "Class3" }
];

