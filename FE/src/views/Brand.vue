<template>
	<Header></Header>
	<div class="container mt-4 mb-4">
		<div class="">
			<div class="mb-4 fst-italic">
				Trang chủ / nhà cung cấp
			</div>
			<DataView :value="brands" :layout="layout" :paginator="true" :rows="6" :sortOrder="sortOrder"
				:sortField="sortField">
				<template #header>
					<div class="grid grid-nogutter">
						<div class="col-6 fw-bold fs-4" style="text-align: left; color: #fbae40;">
							Danh sách nhà cung cấp
						</div>
						<div class="col-6" style="text-align: right">
							<DataViewLayoutOptions v-model="layout" />
						</div>
					</div>
				</template>

				<template #list="slotProps">
					<div class="col-12">
						<div class="product-list-item">
							<img :src="'/src/assets/images/' + slotProps.data.images + '.png'"
								:alt="slotProps.data.name" />
							<div class="product-list-detail">
								<div class="product-name">{{ slotProps.data.name }}</div>
								<!-- <div class="product-description">{{ slotProps.data.description }}</div> -->
								<!-- <Rating :modelValue="slotProps.data.rating" :readonly="true" :cancel="false"></Rating> -->
								<!-- <i class="pi pi-tag product-category-icon"></i><span class="product-category">{{
										slotProps.data.category
								}}</span> -->
							</div>
							<div class="product-list-action">
								<!-- <span class="product-price">${{ slotProps.data.price }}</span> -->
								<!-- <router-link style="text-decoration: none;" :to="'/brand/' + slotProps.data.url"><Button
										class="p-button-rounded p-button-warning" icon="pi pi-angle-right"
										:disabled="slotProps.data.inventoryStatus === 'OUTOFSTOCK'"></Button>
								</router-link> -->
								<!-- <span :class="'product-badge status-' + slotProps.data.inventoryStatus.toLowerCase()">{{
										slotProps.data.inventoryStatus
								}}</span> -->
							</div>
						</div>
					</div>
				</template>

				<template #grid="slotProps">
					<div class="col-12 md:col-4">
						<div class="product-grid-item card">
							<div class="product-grid-item-top">
								<!-- <div>
									<i class="pi pi-tag product-category-icon"></i>
									<span class="product-category">{{ slotProps.data.category }}</span>
								</div> -->
								<!-- <span :class="'product-badge status-' + slotProps.data.inventoryStatus.toLowerCase()">{{
										slotProps.data.inventoryStatus
								}}</span> -->
							</div>
							<div class="product-grid-item-content">
								<img :src="'/src/assets/images/' + slotProps.data.images + '.png'"
									:alt="slotProps.data.name" />
								<div class="product-name">{{ slotProps.data.name }}</div>
								<div class="product-description">{{ slotProps.data.description }}</div>
								<!-- <Rating :modelValue="slotProps.data.rating" :readonly="true" :cancel="false"></Rating> -->
							</div>
							<div class="product-grid-item-bottom">
								<!-- <span class="product-price">${{ slotProps.data.price }}</span> -->
								<!-- <router-link style="text-decoration: none;" :to="'/brand/' + slotProps.data.url"><Button
										class="p-button-rounded p-button-warning" icon="pi pi-angle-right"
										:disabled="slotProps.data.inventoryStatus === 'OUTOFSTOCK'"></Button>
								</router-link> -->
							</div>
						</div>
					</div>
				</template>
			</DataView>
		</div>
	</div>
	<Footer></Footer>
</template>

<script>
import Header from '../components/Layouts/Header.vue'
import Footer from '../components/Layouts/Footer.vue'
import { HTTP } from '../http-common.js'
import { RouterLink } from 'vue-router'
export default {
	data() {
		return {
			brands: null,
			layout: 'grid',
			sortKey: null,
			sortOrder: null,
			sortField: null,
			sortOptions: [
				{ label: 'Price High to Low', value: '!price' },
				{ label: 'Price Low to High', value: 'price' },
			]
		}
	},
	mounted() {
		this.getAllBrand()
	},
	methods: {
		getAllBrand() {
			HTTP.get('Brand/getAll').then(res => {
				if (res.data) {
					this.brands = res.data
				}
			})
		},
	},
	components: { Header, Footer }
}
</script>

<style lang="scss" scoped>
.card {
	background: #ffffff;
	padding: 2rem;
	box-shadow: 0 2px 1px -1px rgba(0, 0, 0, .2), 0 1px 1px 0 rgba(0, 0, 0, .14), 0 1px 3px 0 rgba(0, 0, 0, .12);
	border-radius: 4px;
	margin-bottom: 2rem;
}

.p-dropdown {
	width: 14rem;
	font-weight: normal;
}

.product-name {
	font-size: 1.5rem;
	font-weight: 700;
}

.product-description {
	margin: 0 0 1rem 0;
}

.product-category-icon {
	vertical-align: middle;
	margin-right: .5rem;
}

.product-category {
	font-weight: 600;
	vertical-align: middle;
}

::v-deep(.product-list-item) {
	display: flex;
	align-items: center;
	padding: 1rem;
	width: 100%;

	img {
		width: 50px;
		box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
		margin-right: 2rem;
	}

	.product-list-detail {
		flex: 1 1 0;
	}

	.p-rating {
		margin: 0 0 .5rem 0;
	}

	.product-price {
		font-size: 1.5rem;
		font-weight: 600;
		margin-bottom: .5rem;
		align-self: flex-end;
	}

	.product-list-action {
		display: flex;
		flex-direction: column;
	}

	.p-button {
		margin-bottom: .5rem;
	}
}

::v-deep(.product-grid-item) {
	margin: .5rem;
	border: 1px solid var(--surface-border);

	.product-grid-item-top,
	.product-grid-item-bottom {
		display: flex;
		align-items: center;
		justify-content: center;
	}

	img {
		box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
		margin: 2rem 0;
	}

	.product-grid-item-content {
		text-align: center;
	}

	.product-price {
		font-size: 1.5rem;
		font-weight: 600;
	}
}

@media screen and (max-width: 576px) {
	.product-list-item {
		flex-direction: column;
		align-items: center;

		img {
			margin: 2rem 0;
		}

		.product-list-detail {
			text-align: center;
		}

		.product-price {
			align-self: center;
		}

		.product-list-action {
			display: flex;
			flex-direction: column;
		}

		.product-list-action {
			margin-top: 2rem;
			flex-direction: row;
			justify-content: space-between;
			align-items: center;
			width: 100%;
		}
	}
}
</style>
