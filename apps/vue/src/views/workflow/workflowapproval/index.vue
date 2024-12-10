<template>
    <OnboardingTable />
</template>
  
  <script lang="ts">
    import { defineComponent } from 'vue';
    import OnboardingTable from './components/OnboardingTable.vue';
    export default defineComponent({
      name: 'Onboardings',
      components: { OnboardingTable },
      setup() {},
    });
  </script>
  