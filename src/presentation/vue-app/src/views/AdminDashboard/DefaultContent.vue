<template>
  <div>
    <div class="text-h2 my-4">Welcome to Admin Dashboard</div>
    <div class="default-content">
      <div style="margin-right: 4rem; margin-bottom: 4rem">
        <TourListsCard />
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions } from "vuex";
import TourListsCard from "@/components/TourListsCard";

export default {
  name: "DefaultContent",
  methods: {
    ...mapActions("tourModule", ["getTourListsAction"]),
  },
  mounted() {
    this.getTourListsAction();
  },
  components: {
    TourListsCard,
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
