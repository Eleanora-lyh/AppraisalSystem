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
import { HostpitalLevelTypes } from "../config";

@Component({
    mixins: [formMixin()]
})
export default class Index extends Vue {
    @Action
    getCity;
    @State
    getCityData;

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
             "Entity.HostpitalName":{
                 label: "医院名称",
                 rules: [{ required: true, message: "医院名称"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "input"
            },
             "Entity.HostpitalLevel":{
                 label: "医院级别",
                 rules: [{ required: true, message: "医院级别"+this.$t("form.notnull"),trigger: "blur" }],
                    type: "select",
                    children: HostpitalLevelTypes,
                    props: {
                        clearable: true
                    }
            },
             "Entity.LocationId":{
                 label: "医院地点",
                 rules: [],
                    type: "select",
                    children: this.getCityData,
                    props: {
                        clearable: true
                    }
            }
                
            }
        };
    }
    beforeOpen() {
        this.getCity();

    }
}
</script>
