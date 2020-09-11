<template>
    <form  v-on:submit.prevent="submit">
        <div class="form-group">
            <input type="text" v-model="searchingData" placeholder="What're you searching for?" class="form-control form-control-underlined border-info">
        </div>
        <div>
            
        </div>
    </form>
</template>

<script>
export default {
    name: 'Search',
    data() {
        return {
            searchingData: ''
        }
    },
    methods: {
        submit() {
            alert(this.searchingData);
            this.searchingData = '';
        }
    },
}
</script>

<style>
.form-control-underlined {
  border-width: 0;
  border-bottom-width: 1px;
  border-radius: 0;
  padding-left: 0;
}

.form-control::placeholder {
  font-size: 0.95rem;
  color: #949da7;
  font-style: italic;
}
</style>