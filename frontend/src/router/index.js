import Vue from 'vue'
import VueRouter from 'vue-router'
import Students from '../views/Students.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'students',
    component: Students
  },
  {
    path: '/create-student',
    name: 'create-student',
    component: () => import('../views/AddStudent.vue')
  },
  {
    path: '/edit/:id',
    name: 'edit',
    component: () => import('../views/AddStudent.vue')
  },
  {
    path: '/delete/:id',
    name: 'delete',
    //component: () => import('../views/EquipamentosView.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
