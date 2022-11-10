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
                    <div class="fw-bold fs-5 mt-2 mb-2 "><i class="bi bi-bookmarks"></i> Quản lý người dùng</div>
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
                    Không tìm thấy người dùng.
                </template>
                <Column field="id" header="ID" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="name" header="Họ và tên" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="name" header="Giới tính" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="name" header="Ngày sinh" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="name" header="Số điện thoại" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="" header="" style="min-width: 14rem;">
                    <Button class="p-button-rounded p-button-warning" icon="pi pi-pencil" />
                    <Button class="p-button-rounded p-button-danger" icon="pi pi-trash" />
                </Column>
            </DataTable>
        </div>
    </div>
</template>

<script>
import {HTTP} from '../../../http-common.js'
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