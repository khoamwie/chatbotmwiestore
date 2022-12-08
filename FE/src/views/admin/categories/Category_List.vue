<template>
    <Header></Header>
    <div class="row mt-4">
        <div class="col-sm-2">
            <Sidebar></Sidebar>
        </div>
        <div class="col-right">
            <DataTable :value="data" :paginator="true" class="p-datatable-customers" :rows="5" dataKey="id"
                :rowHover="true" v-model:filters="filters" 
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[5,10,15]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                responsiveLayout="scroll">
                <template #header>
                    <div class="fw-bold fs-5 mt-2 mb-2 "><i class="bi bi-bookmarks"></i> Quản lý danh mục</div>
                    <div class="header-table">
                        <div>
                            <Button class="p-button-rounded p-button-success" icon="pi pi-plus" @click="showAdd"/>
                        </div>
                        <div>
                            <span class="p-input-icon-left">
                                <i class="pi pi-search" />
                                <InputText class="p-inputtext-sm" v-model="filters['global'].value"
                                    placeholder="Tìm kiếm ..." />
                            </span>
                        </div>
                    </div>
                </template>
                <template #empty>
                    Không tìm thấy danh mục.
                </template>
                <Column field="id" header="Id" sortable>
                    <template #body="{ data }">
                        {{ data.id }}
                    </template>
                </Column>
                <Column field="name" header="Tên danh mục" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="" header="">
                    <template #body="{ data }">
                        <Button class="p-button-rounded p-button-warning" icon="pi pi-pencil" />
                        &nbsp;
                        <Button class="p-button-rounded p-button-danger" icon="pi pi-trash" />
                    </template>
                </Column>
            </DataTable>

            <Dialog v-model:visible="cateDialog" :style="{width: '450px'}" header="Product Details" :modal="true" class="p-fluid">
            <div class="field">
                <label for="name">Name</label>
                <InputText id="name" v-model="name" required="true" autofocus :class="{'p-invalid': submitted && !product.name}" />
                <small class="p-error" v-if="submitted && !product.name">Name is required.</small>
            </div>

            <template #footer>
                <Button label="Cancel" icon="pi pi-times" class="p-button-text" @click="hideDialog"/>
                <Button label="Save" icon="pi pi-check" class="p-button-text" @click="saveProduct" />
            </template>
        </Dialog>

        </div>
    </div>
</template>

<script>
import { HTTP } from '../../../http-common.js'
import { FilterMatchMode } from 'primevue/api'
import Header from '../../../components/admin/Header.vue'
import Sidebar from '../../../components/admin/Sidebar.vue'
export default {
    data() {
        return {
            data: null,
            cateDialog: false,
            filters: {
                'global': { value: null, matchMode: FilterMatchMode.CONTAINS }
            }
        }
    },
    mounted() {
        this.getAll()
    },
    methods: {
        getAll() {
            HTTP.get('Category/getAll').then(res => {
                if (res.data) {
                    this.data = res.data;
                }
            })
        },
        showAdd(){
            this.cate = {}
            this.cateDialog = true
            this.submitted = false
        }
    },
    components: { Header, Sidebar }
}
</script>

<style lang="scss" scoped>
.col-right {
    flex: 1;
}

.row {
    margin-right: 0 !important;
}

.header-table {
    display: flex;
    justify-content: space-between;
}

::v-deep(.p-paginator) {
    .p-paginator-current {
        margin-left: auto;
    }
}

::v-deep(.p-progressbar) {
    height: .5rem;
    background-color: #D8DADC;

    .p-progressbar-value {
        background-color: #607D8B;
    }
}

::v-deep(.p-datepicker) {
    min-width: 25rem;

    td {
        font-weight: 400;
    }
}

::v-deep(.p-datatable.p-datatable-customers) {
    .p-datatable-header {
        padding: 1rem;
        text-align: left;
        font-size: 1.5rem;
    }

    .p-paginator {
        padding: 1rem;
    }

    .p-datatable-thead>tr>th {
        text-align: left;
    }

    .p-datatable-tbody>tr>td {
        cursor: auto;
    }

    .p-dropdown-label:not(.p-placeholder) {
        text-transform: uppercase;
    }
}
</style>