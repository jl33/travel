import Vue from "vue";
import Vuex from "vuex";
import CreateLogger from "vuex/dist/logger";
import tourModule from "./tour";

Vue.use(Vuex);
const debug=process.env.NODE_ENV !== "production";
const plugins = debug ? [CreateLogger({})]:[];

export default new Vuex.Store({
  // state: {},
  // mutations: {},
  // actions: {},
  modules:{
    tourModule,
  },
  plugins,
});
