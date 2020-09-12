<template>
    <div class="container mt-3">
        <form  v-on:submit.prevent="submit" class="rounded px-5 py-4 shadow bg-white text-left">
            <div class="form-group">
                <input type="text" v-model="searchingData" placeholder="Type search keywords separeted by spaces...(Or leave it blank to get all records)" class="form-control form-control-underlined border-info">
            </div>
        </form>
        <div class="row container mt-3 justify-content-center text-left">
            <div v-for="response in responseData.data" :key="response" class="m-3 col-5 rounded px-5 py-4 shadow bg-white">
                <div v-for="(value, key) in response" :key="key">
                    <strong>{{key}}</strong> : {{value}}
                </div>
            </div>
        </div>
        
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'Search',
    data() {
        return {
            searchingData: '',
            responseData: ''
        }
    },
    computed: {
        searchComputed() {
            let data = this.searchingData;
            return data.replaceAll(' ', ' AND ');
        }
    },
    methods: {
        async submit() {
            const url = 'api/search';
            const data = JSON.stringify(this.searchComputed);
            axios.post(url, data,
            {
                 headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then((response) => {
                console.log(response);
                this.responseData = response;
            })
            .catch((error) => {
                console.log(error);
            });
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