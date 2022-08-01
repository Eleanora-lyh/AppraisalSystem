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
             "Entity.Temparature":{
                 label: "体温",
                 rules: [{ required: true, message: "体温"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.Remark":{
                 label: "备注",
                 rules: [],
                    type: "input"
            },
             "Entity.PatientID":{
                 label: "Patient",
                 rules: [{ required: true, message: "Patient"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: this.getPatientData,
                    props: {
                        clearable: true
                    }
            }
                
            }
        };
    }
    beforeOpen() {
        this.getPatient();

    }
}
</script>
