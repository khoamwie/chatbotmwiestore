<template>
    <Header></Header>
    <div class="container mt-4 mb-4">
        <div class="mb-4 fst-italic">
            Trang chủ / Danh sách yêu thích 
        </div>
        <div>
            <DataTable :value="product" :paginator="false" class="p-datatable-customers" :rows="10" dataKey="id"
                :rowHover="true" v-model:selection="selectedCustomers" v-model:filters="filters" filterDisplay="menu"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[10, 25, 50]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                responsiveLayout="scroll">
                <template #header>
                    <div class="header-table">
                        <div class="fw-bold fs-5 mt-2 mb-2" style="color: #fbae40;"><i class="bi bi-cart3"></i> Sản phẩm yêu thích</div>
                        <!-- <div>
                            <Button class="p-button-sm p-button-outlined p-button-warning" label="Cập nhật giỏ hàng" />
                        </div> -->
                    </div>
                </template>
                <template #empty>
                    Không tìm sản phẩm.
                </template>
                <Column field="product_id" header="Tên sản phẩm" sortable>
                    <template #body="{ data }">
                        {{ data.product_id }}
                    </template>
                </Column>
                <Column field="product_id" header="Tên sản phẩm" sortable>
                    <template #body="{ data }">
                        {{ data.images }}
                    </template>
                </Column>
                <!-- <Column field="number" header="Số lượng" sortable>
                    <div class="field col-12 md:col-3">
                        <InputNumber inputId="vertical" v-model="value19" mode="decimal" showButtons
                            buttonLayout="vertical" style="width:4rem" decrementButtonClass="p-button-secondary"
                            incrementButtonClass="p-button-secondary" incrementButtonIcon="pi pi-plus"
                            decrementButtonIcon="pi pi-minus" />
                    </div>
                </Column>
                <Column field="price" header="Giá" sortable style="min-width: 5rem;">
                    <template #body="{ data }">
                        {{ data.price }}
                    </template>
                </Column> -->
                <Column field="" header="">
                    <Button class="p-button-warning" icon="pi pi-shopping" /> 
                    &nbsp;
                    <Button class="p-button-danger" label="pi pi-trash" />
                </Column>
            </DataTable>
        </div>
        <!-- <div class="mt-4 button-cart">
            <Button class="p-button-sm p-button-outlined p-button-warning" label="Tiến hành thanh toán" />
        </div> -->
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
        this.getCardbyUserId()
    },
    methods:{
        getCardbyUserId(){
            this.userid = localStorage.getItem('userid')
            HTTP.get('Card/' + this.userid).then(res => {
                if(res.data){
                    this.card = res.data
                }
            })
        },
        getAllProduct(){
            HTTP.get('Product/getAll').then(res => {
                if(res.data){
                    this.product = res.data
                }
            })
        },
        getNamebyProductId(value){
            
        }
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

