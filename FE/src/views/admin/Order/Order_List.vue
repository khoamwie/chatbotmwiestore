<template>
    <Header></Header>
    <div class="row mt-4">
        <div class="col-sm-2">
            <Sidebar></Sidebar>
        </div>
        <div class="col-right">
            <DataTable :value="card" :paginator="true" class="p-datatable-customers" :rows="5" dataKey="id" sortField="id" sortOrder="-1"
                :rowHover="true" v-model:filters="filters" filterDisplay="menu" :loading="loading"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[5, 10, 15]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                :globalFilterFields="['global', 'name', 'address', 'date', 'status']" responsiveLayout="scroll">
                <template #header>
                    <div class="fw-bold fs-5 mt-2 mb-2 "><i class="bi bi-bookmarks"></i> Quản lý đơn đặt hàng</div>
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
                    Không tìm thấy sản phẩm.
                </template>
                <Column field="id" header="ID" sortable>
                    <template #body="{ data }">
                        {{ data.id }}
                    </template>
                </Column>
                <Column field="userid" header="Khách hàng" sortable>
                    <template #body="{ data }">
                        {{ data.user_id }}
                    </template>
                </Column>
                <Column field="address" header="Địa chỉ" sortable>
                    <template #body="{ data }">
                        {{ data.address }}
                    </template>
                </Column>
                <Column field="date" header="Ngày" sortable dataType="date">
                    <template #body="{ data }">
                        {{ formatDate(data.date) }}
                        <!-- {{data.date}} -->
                    </template>
                    <template #filter="{ filterModel }">
                        <Calendar v-model="filterModel.value" dateFormat="mm/dd/yy" placeholder="mm/dd/yyyy" />
                    </template>
                </Column>
                <Column field="status" filterField="status" header="Trạng thái" sortable :showFilterMatchModes="false">
                    <template #body="{ data }">
                        {{ getStatus(data.status) }}
                    </template>
                    <template #filter="{ filterModel }">
                        <div class="mb-3 font-bold">Chọn trạng thái</div>
                        <MultiSelect v-model="filterModel.value" :options="status" optionValue="code" optionLabel="name"
                            placeholder="Any" class="p-column-filter">
                            <template #option="slotProps">
                                <div class="p-multiselect-representative-option">
                                    <span class="image-text">{{ slotProps.option.name }}</span>
                                </div>
                            </template>
                        </MultiSelect>
                    </template>
                </Column>
                <Column field="" header="" style="min-width: 14rem;">
                    <template #body="{ data }">
                        <Button class="p-button-rounded p-button-success" icon="pi pi-check"
                            @click="accepOrder(data.id, data.user_id)"
                            :hidden="data.status == 1 ? false : true" />&nbsp;
                        <Button class="p-button-rounded p-button-success" icon="pi pi-truck"
                            @click="shipOrder(data.id, data.user_id)" :hidden="data.status == 2 ? false : true" />&nbsp;
                        <Button class="p-button-rounded p-button-warning" icon="pi pi-search" @click="" />&nbsp;
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
import moment from 'moment'
export default {
    data() {
        return {
            userid: null,
            card: null,
            user: null,
            accepthidden: true,
            rejecthidden: true,
            filters: {
                'global': { value: null, matchMode: FilterMatchMode.CONTAINS },
                'date': { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.DATE_IS }] },
                'status': { value: null, matchMode: FilterMatchMode.IN },
            },
            status: [
                { name: 'Chờ xác nhận', code: 1 },
                { name: 'Đang giao', code: 2 },
                { name: 'Giao thành công', code: 3 },
                { name: 'Đã hủy', code: 4 },
            ]
        }
    },
    mounted() {
        this.userid = localStorage.getItem('userid')
        this.getBillIdbyUserId()
    },
    methods: {
        getBillIdbyUserId() {
            HTTP.get('Bill/getAll').then(res => {
                if (res.data) {
                    const docs = res.data.map(row => {
                        return {
                            ...row,
                            date: new Date(row.date)
                        }
                    })
                    this.card = docs;
                    // console.log(docs)

                    this.card.forEach(element => {
                        this.total += element.gia
                    });
                }
            })
        },
        getStatus(value) {
            if (value == 1)
                return "Chờ xác nhận"
            if (value == 2)
                return "Đang giao"
            if (value == 3)
                return "Giao thành công"
            if (value == 4)
                return "Đã hủy"
        },
        getAllUser() {
            HTTP.get('User/getAll').then(res => {
                if (res.data) {
                    this.user = res.data
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
        accepOrder(id, user_id) {
            HTTP.put('Bill/acceptOrder/' + id + '&' + user_id)
            location.reload()
        },
        rejectOrder(id, user_id) {
            HTTP.put('Bill/rejectOrder/' + id + '&' + user_id)
            location.reload()
        },
        shipOrder(id, user_id) {
            HTTP.put('Bill/shipOrder/' + id + '&' + user_id)
            location.reload()
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