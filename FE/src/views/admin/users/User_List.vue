<template>
    <Header></Header>
    <div class="row mt-4">
        <div class="col-sm-2">
            <Sidebar></Sidebar>
        </div>
        <div class="col-right">
            <DataTable :value="users" :paginator="true" class="p-datatable-customers" :rows="5" dataKey="id"
                sortField="id" sortOrder="-1" :rowHover="true" v-model:filters="filters" filterDisplay="menu"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[5, 10, 15]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                :globalFilterFields="['global', 'name','gender']" responsiveLayout="scroll">
                <template #header>
                    <div class="fw-bold fs-5 mt-2 mb-2 "><i class="bi bi-person"></i> Quản lý người dùng</div>
                    <div class="header-table">
                        <div>
                            <!-- <Button class="p-button-rounded p-button-success" icon="pi pi-plus" /> -->
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
                <Column field="id" header="ID" sortable>
                    <template #body="{ data }">
                        {{ data.id }}
                    </template>
                </Column>
                <Column field="name" header="Tên người dùng" sortable>
                    <template #body="{ data }">
                        {{ data.name }}
                    </template>
                </Column>
                <Column field="gender" filterField="gender" header="Giới tính" sortable :showFilterMatchModes="false">
                    <template #body="{ data }">
                        {{ getGender(data.gender) }}
                    </template>
                    <template #filter="{ filterModel }">
                        <div class="mb-3 font-bold">Chọn giới tính</div>
                        <MultiSelect v-model="filterModel.value" :options="gender" optionValue="code" optionLabel="name"
                            placeholder="Any" class="p-column-filter">
                            <template #option="slotProps">
                                <div class="p-multiselect-representative-option">
                                    <span class="image-text">{{ slotProps.option.name }}</span>
                                </div>
                            </template>
                        </MultiSelect>
                    </template>
                </Column>
                <Column field="birthdate" header="Ngày sinh" sortable>
                    <template #body="{ data }">
                        {{ formatDate(data.birthdate) }}
                    </template>
                </Column>
                <Column field="phone" header="Số điện thoại" sortable>
                    <template #body="{ data }">
                        {{ data.phone }}
                    </template>
                </Column>
                <Column field="lock" filterField="lock" header="Trạng thái" sortable :showFilterMatchModes="false">
                    <template #body="{ data }">
                        {{ getLock(data.lock) }}
                    </template>
                    <template #filter="{ filterModel }">
                        <div class="mb-3 font-bold">Chọn giới tính</div>
                        <MultiSelect v-model="filterModel.value" :options="lock" optionValue="code" optionLabel="name"
                            placeholder="Any" class="p-column-filter">
                            <template #option="slotProps">
                                <div class="p-multiselect-representative-option">
                                    <span class="image-text">{{ slotProps.option.name }}</span>
                                </div>
                            </template>
                        </MultiSelect>
                    </template>
                </Column>
                <Column field="" header="">
                    <template #body="{ data }">
                        <Button class="p-button-rounded p-button-danger" icon="pi pi-lock" @click="lockUser"/>
                        &nbsp;
                        <Button class="p-button-rounded p-button-success" icon="pi pi-comment" />
                        &nbsp;
                        <Button class="p-button-rounded p-button-success" icon="pi pi-star" />
                    </template>
                </Column>
            </DataTable>
        </div>
    </div>
</template>

<script>
import { HTTP } from '../../../http-common.js'
import { FilterMatchMode, FilterOperator } from 'primevue/api'
import Header from '../../../components/admin/Header.vue'
import Sidebar from '../../../components/admin/Sidebar.vue'
export default {
    data() {
        return {
            users: null,
            filters: {
                'global': { value: null, matchMode: FilterMatchMode.CONTAINS },
                'gender': { value: null, matchMode: FilterMatchMode.IN },
                'lock': { value: null, matchMode: FilterMatchMode.IN },
            },
            gender: [
                { name: 'Nam', code: 0 },
                { name: 'Nữ', code: 1 }
            ],
            lock: [
                { name: 'Chưa khóa', code: 0 },
                { name: 'Đã khóa', code: 1 }
            ],
        }
    },
    mounted() {
        this.getAll()
    },
    methods: {
        getAll() {
            HTTP.get('User/getAll').then(res => {
                if (res.data) {
                    this.users = res.data;
                }
            })
        },
        formatDate(value) {
            var date = new Date(value)
            date.formatDate
            return date.toLocaleDateString('en-US', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric',
            });
        },
        getGender(value) {
            if (value == 0)
                return "Nam"
            if (value == 1)
                return "Nữ"
        },
        getLock(value) {
            if (value == 0)
                return "Chưa khóa"
            if (value == 1)
                return "Đã khóa"
        },
        lockUser(value){
            HTTP.put('User/lockUser/' + value).then(res => {})
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