<template>
    <Header></Header>
    <div class="container mt-4 mb-4">
        <div class="mb-4 fst-italic">
            Trang chủ / Lịch sử mua hàng
        </div>
        <div>
            <DataTable :value="card" :paginator="true" class="p-datatable-customers" :rows="5" dataKey="id"
                :rowHover="true" v-model:filters="filters" filterDisplay="menu" :loading="loading"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[5, 10, 15]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                :globalFilterFields="['name', 'country.name', 'representative.name', 'status']"
                responsiveLayout="scroll">
                <template #header>
                    <div class="fw-bold fs-5 mt-2 mb-2 "><i class="bi bi-bookmarks"></i> Lịch sử mua hàng</div>
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
                <Column field="id" header="Mã đơn hàng" sortable>
                    <template #body="{ data }">
                        {{ data.id }}
                    </template>
                </Column>
                <Column field="address" header="Địa chỉ" sortable>
                    <template #body="{ data }">
                        {{ data.address }}
                    </template>
                </Column>
                <Column field="date" header="Ngày" sortable>
                    <template #body="{ data }">
                        {{ formatDate(data.date) }}
                    </template>
                    <template #filter="{ filterModel }">
                        <Calendar v-model="filterModel.value" dateFormat="mm/dd/yy" placeholder="mm/dd/yyyy" />
                    </template>
                </Column>
                <Column field="status" header="Trạng thái" sortable>
                    <template #body="{ data }">
                        {{ getStatus(data.status) }}
                    </template>
                    <template #filter="{ filterModel }">
                        <Dropdown v-model="filterModel.value" :options="statuses" placeholder="Any"
                            class="p-column-filter" :showClear="true">
                            <template #value="slotProps">
                                <span :class="'customer-badge status-' + slotProps.value">{{ slotProps.value }}</span>
                            </template>
                            <template #option="slotProps">
                                <span :class="'customer-badge status-' + slotProps.option">{{ slotProps.option }}</span>
                            </template>
                        </Dropdown>
                    </template>
                </Column>
                <Column field="" header="" style="min-width: 14rem;">
                    <template #body="{ data }">
                        <!-- <Button class="p-button-rounded p-button-success" icon="pi pi-comments" />&nbsp;
                        <Button class="p-button-rounded p-button-success" icon="pi pi-comment" />&nbsp; -->
                        <!-- <Button class="p-button-rounded p-button-success" icon="pi pi-check"
                            @click="accepOrder(data.id, data.user_id)"
                            :hidden="data.status == 1 ? false : true" />&nbsp; -->
                        <Button class="p-button-rounded p-button-danger" icon="pi pi-times"
                            @click="rejectOrder(data.id, data.user_id)"
                            :hidden="data.status == 1 ? false : true" />&nbsp;
                        <!-- <Button class="p-button-rounded p-button-success" icon="pi pi-truck"
                            @click="shipOrder(data.id, data.user_id)" :hidden="data.status == 2 ? false : true" />&nbsp; -->
                        <Button class="p-button-rounded p-button-warning" icon="pi pi-search"
                            @click=""/>&nbsp;
                    </template>
                </Column>
            </DataTable>
        </div>
    </div>
    <Footer></Footer>
</template>

<script>
import { FilterMatchMode } from 'primevue/api'
import Header from "../components/Layouts/Header.vue";
import Footer from "../components/Layouts/Footer.vue";
import {HTTP} from '../http-common.js'
export default {
    data() {
        return {
            card: null, 
            product: null,
            userid: null,
            filters: {
                'global': { value: null, matchMode: FilterMatchMode.CONTAINS }
            }
        }
    },
    mounted(){
        this.userid = localStorage.getItem('userid')
        this.getBill()
    },
    methods:{
        getBill(){
            HTTP.get('Bill/getbyUserId/' + this.userid).then(res => {
                if(res.data){
                    this.card = res.data
                }
            })
        },
        getStatus(value) {
            if (value == 1)
                return "Chờ xác nhận"
            if (value == 2)
                return "Đang giao"
            if (value == 3)
                return "Đã giao"
            if (value == 4)
                return "Đã hủy"
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
        rejectOrder(id, user_id) {
            HTTP.put('Bill/rejectOrder/' + id + '&' + user_id)
            location.reload()
        },
    },
    components: { Header, Footer }
}
</script>

<style lang="scss" scoped>
.button-cart {
    display: flex;
    justify-content: right;
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

