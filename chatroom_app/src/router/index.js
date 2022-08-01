import { createRouter, createWebHashHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'

const routes = [
  {
    path: '/',
    name: 'Login',
    component: LoginView
  },
  {
    path: '/Register',
    name: 'Register',
    component: () => import(/* webpackChunkName: "about" */ '../views/RegisterView.vue'),
    // meta: {
    //   requiresAuth: true
    // }
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

const isLoggedIn = () => {
  const { $cookies } = router.app.config.globalProperties;
  const token = $cookies.get("token");
  return token != null;
}

router.beforeEach((to) => {
  if (to.meta.requiresAuth && !isLoggedIn()) {
    return {
      path: "/",
      name: "Login"
    }
  }
})

export default router
