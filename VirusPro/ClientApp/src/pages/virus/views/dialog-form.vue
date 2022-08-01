<template>
    <wtm-dialog-box :is-show.sync="isShow" :status="status" :events="formEvent">
        <wtm-create-form :ref="refName" :status="status" :options="formOptions" ></wtm-create-form>
    </wtm-dialog-box>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, State } from "vuex-class";
import formMixin from "@/vue-custom/mixin/form-mixin";
import UploadImg from "@/components/page/UploadImg.vue";
import { VirusTypeTypes } from "../config";

@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {
    @Action
    getPatient;
    @State
    getPatientData;

    // 表单结构
    get formOptions() {
        const filterMethod = (query, item) => {
            return item.label.indexOf(query) > -1;
        };
        return {
            formProps: {
                "label-width": "100px"
            },
            formItem: {
                "Entity.ID": {
                    isHidden: true
                },
             "Entity.VirusName":{
                 label: "病毒名称",
                 rules: [{ required: true, message: "病毒名称"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.VirusCode":{
                 label: "病毒代码",
                 rules: [{ required: true, message: "病毒代码"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.VirusRemark":{
                 label: "病毒描述",
                 rules: [],
                    type: "input"
            },
             "Entity.VirusType":{
                 label: "病毒种类",
                 rules: [{ required: true, message: "病毒种类"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: VirusTypeTypes,
                    props: {
                        clearable: true
                    }
            },
             "Entity.Patients":{
                 label: "患者",
                 rules: [],
                    type: "transfer",
                    mapKey: "PatientId",
                    props: {
                        data: this.getPatientData.map(item => ({
                            key: item.Value,
                            label: item.Text
                        })),
                        titles: [this.$t("form.all"), this.$t("form.selected")],
                        filterable: true,
                        filterMethod: filterMethod
                    },
                    span: 24,
                    defaultValue: []
            }
                
            }
        };
    }
    beforeOpen() {
        this.getPatient();

    }
}
</script>
