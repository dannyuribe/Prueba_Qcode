import { createRouter, createWebHashHistory } from "vue-router";
import Base from "@/views/Vehiculo/VehiculoBase.vue";

const routes = [
  {
    path: "/",
    name: "ViewHome",
    component: () => import("@/views/pageHome/Home.vue"),
  },
  {
    path: '/Logeo/',
    component: Base,
    children: [
      {
        path: "inicio-Sesion",
        name: "LogeoPrincipal",
        component: () => import("@/views/Logeo/Logeo.vue"),
      },
      {
        path: "registrar",
        name: "RegistraLogeo",
        component: () => import("@/views/Logeo/RegistraLogeo.vue"),
      },
      {
        path: "valida-registro",
        name: "ValidaRegistroLogeo",
        component: () => import("@/views/Logeo/ValidarRegistroLogeo.vue"),
      },
    ]
  },  
  {
    path: '/Vehiculos/',
    component: Base,
    children: [
      {
        path: 'principal',
        name: 'VehiculoPrincipal',
        component: () => import("@/views/Vehiculo/VehiculoPrincipal.vue")
      },
      {
        path: 'detalle/:id',
        name: 'VehiculoDetalle',
        component: () => import("@/views/Vehiculo/VehiculoDetalle.vue")
      },
      {
        path: "CargaMasiva",
        name: "VehiculoCargaMasiva",
        component: () => import("@/views/Vehiculo/VehiculoCargaMasiva.vue"),
      },
    ],
  }
];
const router = createRouter({
  history: createWebHashHistory(),
  routes,
});
router.beforeEach((to, from, next) => {
  next();
});
export default router;
