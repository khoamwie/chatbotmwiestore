import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('../views/HomeSite.vue')
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/Login.vue')
    },
    {
      path: '/pay/:id',
      name: 'pay',
      component: () => import('../views/Pay.vue')
    },
    {
      path: '/cart/:id',
      name: 'cart',
      component: () => import('../views/Cart.vue')
    },
    {
      path: '/wishlist/:id',
      name: 'wishlist',
      component: () => import('../views/WishList.vue')
    },
    {
      path: '/historybill/:id',
      name: 'historybill',
      component: () => import('../views/HistoryBill.vue')
    },
    {
      path: '/product/:id',
      name: 'detail',
      component: () => import('../views/Detail.vue')
    },
    {
      path: '/knowledge',
      name: 'knowledge',
      component: () => import('../views/Knowledge.vue')
    },
    {
      path: '/brand/all',
      name: 'brand',
      component: () => import('../views/Brand.vue')
    },
    {
      path: '/category',
      name: 'category',
      component: () => import('../views/Category.vue')
    },
    {
      path: '/profile/:id',
      name: 'profile',
      component: () => import('../views/Customer.vue')
    },
    {
      path: '/admin',
      name: 'admin',
      component: () => import('../views/admin/Admin.vue')
    },
    {
      path: '/admin/user',
      name: 'adminuser',
      component: () => import('../views/admin/users/User_List.vue')
    },
    {
      path: '/admin/brand',
      name: 'adminbrand',
      component: () => import('../views/admin/brands/Brand_List.vue')
    },
    {
      path: '/admin/category',
      name: 'admincategory',
      component: () => import('../views/admin/categories/Category_List.vue')
    },
    {
      path: '/admin/product',
      name: 'adminproduct',
      component: () => import('../views/admin/products/Product_List.vue')
    },
    {
      path: '/admin/order',
      name: 'adminorder',
      component: () => import('../views/admin/Order/Order_List.vue')
    },
    {
      path: '/admin/bill',
      name: 'adminbill',
      component: () => import('../views/admin/Bill/Bill_List.vue')
    },
    {
      path: '/admin/promotion',
      name: 'adminpromotion',
      component: () => import('../views/admin/Promotion/Promotion_List.vue')
    },
    {
      path: '/admin/image',
      name: 'adminimage',
      component: () => import('../views/admin/images/Image_List.vue')
    },
  ]
})

export default router
