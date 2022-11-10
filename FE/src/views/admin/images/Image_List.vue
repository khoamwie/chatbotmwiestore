<template>
    <Header></Header>
    <div class="row mt-4">
        <div class="col-sm-2">
            <Sidebar></Sidebar>
        </div>
        <div class="col-right">
            <DataTable :value="customers" :paginator="true" class="p-datatable-customers" :rows="10" dataKey="id"
                :rowHover="true" v-model:selection="selectedCustomers" v-model:filters="filters" filterDisplay="menu"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[10, 25, 50]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                responsiveLayout="scroll">
                <template #header>
                    <div class="fw-bold fs-5 mt-2 mb-2 "><i class="bi bi-bookmarks"></i> Quản lý hình ảnh</div>
                    <div class="header-table">
                        <div>
                            <Button class="p-button-rounded p-button-success" icon="pi pi-plus" />
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
                    Không tìm thấy hình ảnh.
                </template>
                <Column field="id" header="ID" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="name" header="Hình ảnh" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="name" header="Sản phẩm" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="" header="" style="min-width: 14rem;">
                    <Button class="p-button-success" label="Sửa" />
                    <Button class="p-button-danger" label="Xóa" />
                </Column>
            </DataTable>
        </div>
    </div>
</template>

<script>
import { FilterMatchMode } from 'primevue/api'
import Header from '../../../components/admin/Header.vue'
import Sidebar from '../../../components/admin/Sidebar.vue'
export default {
    data() {
        return {
            data: null,
            filters: {
                'global': { value: null, matchMode: FilterMatchMode.CONTAINS }
            }
        }
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