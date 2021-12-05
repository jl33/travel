import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@/views/Main/Home";
import TourLists from "@/views/AdminDashboard/TourLists";
import TourPackages from "@/views/AdminDashboard/TourPackages";
import { authGuard } from "@/auth/auth.guard";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "@/views/Main/About"),
      meta: {
        requiresAuth: false,
      },
  },
  {
    path: "/admin-dashboard",
    component: () => import("@/views/AdminDashboard"),
    meta: {
      requiresAuth: true,
    },
    children: [
      {
        path: "",
        component: () => import("@/views/AdminDashboard/DefaultContent"),
      },
      {
        path: "weather-forecast",
        component: () => import("@/views/AdminDashboard/WeatherForecast"),
      },
      {
        path: "tour-lists",
        component: TourLists,
      },
      {
        path: "tour-packages",
        component: TourPackages,
      },
    ],
  },
  {
    path:"/login",
    component: () => import("@/auth/views/Login"),
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "*",
    redirect: "/",
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  console.log("router.beforeEach");
  authGuard(to, from, next);
});

export default router;
