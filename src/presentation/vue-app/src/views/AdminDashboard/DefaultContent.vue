<template>
  <div>
    <div class="text-h2 my-4">Welcome to Admin Dashboard</div>
    <div class="default-content">
      <div style="margin-right: 4rem; margin-bottom: 4rem">
        <TourListsCard />
        <add-tour-list-form />
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions } from "vuex";
import TourListsCard from "@/components/TourListsCard";
import AddTourListForm from "../../components/AddTourListForm.vue";

export default {
  name: "DefaultContent",
  methods: {
    ...mapActions("tourModule", ["getTourListsAction"]),
  },
  mounted() {
    this.getTourListsAction();
  },
  components: {
    TourListsCard, AddTourListForm,
  },
};
</script>
<style scoped>
.default-content {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: flex-start;
}
</style>
