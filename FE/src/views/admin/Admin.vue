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
                    <div class="row">
                        <div class="col-1"> Chọn năm: </div>
                        <div class="col-2">
                            <span class="p-float-label">
                                <InputText id="inputtext" type="text" v-model="year" />
                                <label for="inputtext">Năm</label>
                            </span>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-1">
                            Bắt đầu:
                        </div>
                        <div class="col-3">
                            <span class="p-float-label">
                                <InputNumber id="inputtext" mode="decimal" v-model="startDay" :min="1" :max="31" />
                                <label for="inputtext">Ngày</label>
                            </span>
                        </div>
                        <div class="col-2">
                            <span class="p-float-label">
                                <InputNumber id="inputtext" mode="decimal" v-model="startMon" :min="1" :max="12" />
                                <label for="inputtext">Tháng</label>
                            </span>
                        </div>
                    </div>
                    <div class="mt-4 row">
                        <div class="col-1">Kết thúc: </div>
                        <div class="col-3">
                            <span class="p-float-label">
                                <InputNumber v-model="endDay" mode="decimal" :min="1" :max="31" />
                                <label for="inputtext">Ngày</label>
                            </span>
                        </div>
                        <div class="col-2">
                            <span class="p-float-label">
                                <InputNumber v-model="endMon" mode="decimal" :min="1" :max="12" />
                                <label for="inputtext">Tháng</label>
                            </span>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-8">
                            <Button class="p-button-success p-button-sm" label="Thống kê" @click="thongke"></Button>
                        </div>
                        <div class="col-4">
                            Tổng doanh thu: {{ sumMoney }}
                        </div>
                    </div>
                </div>
                <div class="mb-5">
                    <div class="mb-4">
                        <Chart type="bar" :data="basicData" :options="basicOptions" />
                    </div>
                    <div class="fs-3 fw-bold fst-italic" style="text-align: center; color: #FFA726;">
                        Biểu đồ thống kê doanh thu
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Header from '../../components/admin/Header.vue'
import Sidebar from '../../components/admin/Sidebar.vue'
import { HTTP } from '../../http-common'
import moment from 'moment'
export default {
    data() {
        return {
            basicData: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                datasets: [
                    {
                        label: 'Doanh thu',
                        backgroundColor: '#FFA726',
                        data: null
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
            year: null,
            startDay: null,
            startMon: null,
            endDay: null,
            endMon: null,
            chartMon: [],
            chartData: [],
            sumMoney: 0
        }
    },
    mounted() {
        // this.thongke()
    },
    methods: {
        async thongke() {
            try {
                // let start = new Date(this.year + "-" + this.startMon + "-" + this.startDay)
                // let end = new Date(this.year + "-" + this.endMon + "-" + this.endDay)
                // let charlabel = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']
                this.chartData = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
                this.sumMoney = 0
                // this.chartMon = []
                for (let i = this.startMon; i <= this.endMon; i++) {
                    // this.chartMon.push(charlabel[i - 1])
                    // let rs = []
                    let total = 0
                    let mon = i < 10 ? "0" + i : i
                    if (this.endMon - this.startMon > 1) {
                        if (i == this.startMon) {
                            // let date0 = new Date(this.year + "-" + i + "-" + this.endDay)
                            let date1 = this.year + "-" + i + "-" + this.startDay
                            await HTTP.get('Bill/getSumMoneyEnd/' + date1 + '&' + this.year + '&' + mon).then(res => {
                                if (res.data) {
                                    // rs = res.data
                                    res.data.forEach(element => {
                                        total += element.total
                                    });
                                }
                            })
                        }
                        else if (i == this.endMon) {
                            let date0 = this.year + "-" + i + "-" + this.endDay
                            // let date1 = new Date(this.year + "-" + i + "-" + this.startDay)
                            await HTTP.get('Bill/getSumMoneyStart/' + date0 + '&' + this.year + '&' + mon).then(res => {
                                if (res.data) {
                                    // rs = res.data
                                    res.data.forEach(element => {
                                        total += element.total
                                    });
                                }
                            })
                        }
                        else {
                            // let date0 = new Date(this.year + "-" + i + "-" + this.endDay)
                            // let date1 = new Date(this.year + "-" + i + "-" + this.startDay)
                            await HTTP.get('Bill/getSumMoneyMon/' + this.year + '&' + mon).then(res => {
                                if (res.data) {
                                    // rs = res.data
                                    res.data.forEach(element => {
                                        total += element.total
                                    });
                                }
                            })
                        }
                    } else {
                        let date0 = this.year + "-" + i + "-" + this.endDay
                        let date1 = this.year + "-" + i + "-" + this.startDay
                        await HTTP.get('Bill/getSumMoney/' + date1 + '&' + date0).then(res => {
                            if (res.data) {
                                // rs = res.data
                                res.data.forEach(element => {
                                    total += element.total
                                });
                            }
                        })
                    }

                    // rs.forEach(element => {
                    //     total += element.Total
                    // });
                    // this.chartData.push(total)
                    this.chartData[i - 1] = total
                    this.sumMoney += total
                    // console.log(rs)


                }
                //  console.log(this.chartData)
                //  console.log(this.chartMon)
                // this.basicData.labels = this.chartMon
                this.basicData.datasets[0].data = this.chartData
            }catch(error){
                alert('Nhap dinh dang ngay khong dung')
                location.reload()
            }

        },

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

