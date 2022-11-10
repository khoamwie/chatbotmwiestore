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
      path: '/cart',
      name: 'cart',
      component: () => import('../views/Cart.vue')
    },
    {
      path: '/detail',
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
      path: '/customer',
      name: 'customer',
      component: () => import('../views/Customer.vue')
    },
    {
      path: '/admin',
      name: 'admin',
      component: () => import('../views/admin/Admin.vue')
    },
    {
      path: '/admin/user',
      name: 'user',
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
      path: '/admin/image',
      name: 'adminimage',
      component: () => import('../views/admin/images/Image_List.vue')
    },
  ]
})

export default router
