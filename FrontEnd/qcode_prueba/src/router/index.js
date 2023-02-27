import { createRouter, createWebHashHistory } from "vue-router";
import Base from "@/views/Vehiculo/VehiculoBase.vue";

const routes = [
  {
    path: "/",
    name: "",
    component: () => import("@/views/pageHome/Home.vue"),
  },
  {
    path: "/Logeo",
    name: "LogeoPrincipal",
    component: () => import("@/views/Logeo/Logeo.vue"),
  },
  {
    path:'/Vehiculos/',  
    component: Base,
    children: [
        {
            path:'principal',
            name:'VehiculoPrincipal',
            component: () => import("@/views/Vehiculo/VehiculoPrincipal.vue")
        },
        {
            path:'detalle/:id',
            name:'VehiculoDetalle',
            component: () => import("@/views/Vehiculo/VehiculoDetalle.vue")
        }
    ],
},
];
const router = createRouter({
  history: createWebHashHistory(),
  routes,
});
router.beforeEach((to, from, next) => {
  next();
});
export default router;
