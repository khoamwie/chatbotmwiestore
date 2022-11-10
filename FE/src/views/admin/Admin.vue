<template>
    <Header></Header>
    <div class="row mt-2">
        <div class="col-sm-2">
            <Sidebar></Sidebar>
        </div>
        <div class="col-right">
            <div style="width: 90%;">
                <div class="Admin-title fw-bold mb-4"><i class="bi bi-graph-up-arrow"></i> Thống kê doanh thu</div>
                <div class="mb-4">
                    <Dropdown v-model="selectedCity" :options="cities" optionLabel="name" placeholder="Chọn năm" />
                </div>
                <Chart type="bar" :data="basicData" :options="basicOptions" />
            </div>
        </div>
    </div>
</template>

<script>
import Header from '../../components/admin/Header.vue'
import Sidebar from '../../components/admin/Sidebar.vue'
export default {
    data() {
        return {
            basicData: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                datasets: [
                    {
                        label: 'Doanh thu',
                        backgroundColor: '#FFA726',
                        data: [65, 59, 80, 81, 56, 55, 40, 90, 150, 38, 96, 73]
                    },
                    // {
                    //     label: 'Đơn hàng',
                    //     backgroundColor: '#22c55E',
                    //     data: [28, 48, 40, 19, 86, 27, 90]
                    // }
                ]
            },
            basicOptions: {
                plugins: {
                    legend: {
                        labels: {
                            color: '#495057'
                        }
                    }
                },
                scales: {
                    x: {
                        ticks: {
                            color: '#495057'
                        },
                        grid: {
                            color: '#ebedef'
                        }
                    },
                    y: {
                        ticks: {
                            color: '#495057'
                        },
                        grid: {
                            color: '#ebedef'
                        }
                    }
                }
            },
            selectedCity: null,
            cities: [
                { name: '2022' },
                { name: '2021' },
                { name: '2020' },
                { name: '2019' },
                { name: '2018' }
            ]
        }
    },
    components: { Header, Sidebar }
}
</script>

<style scoped>
.Admin-title {
    font-size: 20px;
    /* color: #22c55E; */
}

.col-right {
    flex: 1;
}

.row {
    margin-right: 0 !important;
}
</style>