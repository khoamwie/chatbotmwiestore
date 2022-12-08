<template>
    <Header></Header>
    <div class="row mt-4">
        <div class="col-sm-2">
            <Sidebar></Sidebar>
        </div>
        <div class="col-right">
            <DataTable :value="promotion" :paginator="true" class="p-datatable-customers" :rows="5" dataKey="id"
                :rowHover="true" v-model:filters="filters"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[5, 10, 15]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                responsiveLayout="scroll">
                <template #header>
                    <div class="fw-bold fs-5 mt-2 mb-2 "><i class="bi bi-tags"></i> Quản lý khuyến mãi</div>
                    <div class="header-table">
                        <div>
                            <Button class="p-button-rounded p-button-success" icon="pi pi-plus" @click="openAdd" />
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
                    Không tìm thấy nhà cung cấp.
                </template>
                <Column field="name" header="Tên nhà sản xuất" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="country" header="Ngày bắt đầu" sortable>
                    <template #body="{ data }">
                        {{ formatDate(data.startDate) }}
                    </template>
                </Column>
                <Column field="country" header="Ngày kết thúc" sortable>
                    <template #body="{ data }">
                        {{ formatDate(data.endDate) }}
                    </template>
                </Column>
                <Column field="country" header="Giảm giá" sortable>
                    <template #body="{ data }">
                        {{ data.discount }}
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

            <Dialog v-model:visible="promotionDialog" :style="{ width: '450px' }" header="Chi tiết nhà cung cấp"
                :modal="true" class="p-fluid">
                <div class="field">
                    <label for="name">Tên nhà cung cấp: </label>
                    <InputText id="name" v-model="promotion.name" required="true" autofocus
                        :class="{ 'p-invalid': submitted && !promotion.name }" />
                    <small class="p-error" v-if="submitted && !promotion.name">Vui lòng điền tên nhà cung cấp!</small>
                </div>

                <div class="field">
                    <label for="name">Quốc gia: </label>
                    <InputText id="name" v-model="promotion.country" required="true" autofocus
                        :class="{ 'p-invalid': submitted && !promotion.country }" />
                    <small class="p-error" v-if="submitted && !promotion.country">Vui lòng điền quốc gia!</small>
                </div>

                <template #footer>
                    <Button label="Cancel" icon="pi pi-times" class="p-button-text" @click="hideDialog" />
                    <Button label="Save" icon="pi pi-check" class="p-button-text" @click="saveBrand" />
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
            promotion: null,
            promotionDialog: false,
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
            HTTP.get('Promotion/getAll').then(res => {
                if (res.data) {
                    const docs = res.data.map(row => {
                        return {
                            ...row,
                            startDate: new Date(row.startDate),
                            endDate: new Date(row.endDate)
                        }
                    })
                    this.promotion = docs;
                }
            })
        },
        openAdd() {
            this.promotion = {}
            this.submitted = false
            this.promotionDialog = true
        },
        hideDialog() {
            this.promotionDialog = false;
            this.submitted = false;
        },
        saveBrand() {
            this.submitted = true;
            HTTP.post('Brand/addBrand', {
                name: this.promotion.name,
                country: this.promotion.country
            }).then(res => {
                if (res.status == 200) {
                    // this.promotion = res.data
                    alert('Them san pham vao gio hang thanh cong')
                    location.reload()
                }
            })
        },
        formatDate(value) {
            return value.toLocaleDateString('en-US', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric',
            });
        },
    },
    components: { Header, Sidebar }
}
</script>

<style lang="scss" scoped>
.Admin-title {
    font-size: 25px;
    color: #22c55E;
}

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