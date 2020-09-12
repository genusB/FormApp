<template>
    <div class="col-md-8 rounded px-5 py-4 shadow bg-white text-left mt-3">
        <form id="form" v-on:submit.prevent="submit">
            <div class="row">
                <div class="col-12 form-group">
                    <label class="col-form-label col-form-label-lg font-weight-bold">Flight registration</label>
                </div>
                <div class="col-6 form-group">
                    <label class="col-form-label col-form-label-lg">Full Name <span class="text-info">*</span></label>
                    <input type="text" v-model.trim="$v.submission.fullname.$model" :class="{'is-invalid': validationStatus($v.submission.fullname)}" class="form-control form-control-md">
                    <div v-if="!$v.submission.fullname.required" class="invalid-feedback">The full name is required.</div>
                </div>
                <div class="col-6 form-group">
                    <label class="col-form-label col-form-label-lg">Email <span class="text-info">*</span></label>
                    <input type="email" v-model.trim="$v.submission.email.$model" :class="{'is-invalid': validationStatus($v.submission.email)}" class="form-control form-control-md">
                    <div v-if="!$v.submission.email.required" class="invalid-feedback">The email is required.</div>
                    <div v-if="!$v.submission.email.email" class="invalid-feedback">The email is not valid.</div>
                </div>
                <div class="col-6 form-group">
                    <label class="col-form-label col-form-label-lg">Country <span class="text-info">*</span></label>
                    <country-select v-model.trim="$v.submission.country.$model" :country="$v.submission.country.$model" :class="{'is-invalid': validationStatus($v.submission.country)}" class="form-control form-control-md">
                        <option value="">Select Country</option>
                    </country-select>
                    <div v-if="!$v.submission.country.required" class="invalid-feedback">The country is required.</div>
                </div>
                <div class="col-6 form-group">
                    <label class="col-form-label col-form-label-lg">Gender <span class="text-info">*</span></label>
                        <div class="col-6 form-check">
                            <input class="form-check-input" v-model="$v.submission.gender.$model" :class="{'is-invalid': validationStatus($v.submission.gender)}" type="radio" value="man">
                            <label class="form-check-label" >
                                Man
                            </label>
                        </div>
                        <div class="form-check">
                            <input class="form-check-input" v-model="$v.submission.gender.$model" :class="{'is-invalid': validationStatus($v.submission.gender)}" type="radio" value="woman">
                            <label class="form-check-label">
                                Woman
                            </label>
                        </div>
                    <div v-if="!$v.submission.gender.required" class="invalid-feedback">The gender is required.</div>
                </div>
                <div class="col-6 form-group">
                    <label class="col-form-label col-form-label-lg">Birthday <span class="text-info">*</span></label>
                    <input type="date" v-model="$v.submission.birthday.$model" :class="{'is-invalid': validationStatus($v.submission.birthday)}" name="birthday"
                            min="1900-01-01" class="form-control form-control-md">
                    <div v-if="!$v.submission.birthday.required" class="invalid-feedback">The birthday is required.</div>
                
                </div>
                <div class="col-6 form-group">
                    <label class="col-form-label col-form-label-lg">Comments </label>
                    <textarea v-model.trim="submission.comments" class="form-control form-control-md"></textarea>
                </div>
                <div class="col-12 form-group text-center">
                    <button class="btn btn-vue btn-lg col-4">Save</button>
                </div>
            </div>
        </form>
    </div>
</template>
<script>
import axios from 'axios';
import { required, email} from 'vuelidate/lib/validators'

export default {
    name: 'Form',
    data() {
        return {
            submission: {
                fullname: '', 
                email: '', 
                country: '', 
                birthday: '',
                gender: '',
                comments: null,
            },
        }
    }, 
    validations: {
        submission: {
            fullname: {required},
            email: {required, email},
            country: {required},
            birthday: {required},
            gender: {required}
        }
    },
    methods: {
        submit() {
            this.$v.$touch();
            if (this.$v.$pendding || this.$v.$error) return;

            this.sendSubmission();
            this.$v.$reset();
            this.resetData();
        },
        resetData: function() {
            this.submission.fullname = '';
            this.submission.email = '';
            this.submission.country = '';
            this.submission.birthday = '';
            this.submission.gender = '';
            this.submission.comments = '';
        },

        validationStatus: function(validation) {
            return typeof validation != "undefined" ? validation.$error : false;
        },
        sendSubmission() {
            const data = JSON.stringify(this.submission);
            const host = '/api/save/';
            axios.post(host, data,
            {
                 headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
        }
    }
}
</script>
<style>
.btn-vue{
    background: #35D6ED;
    color: #31485D;
    font-weight: bold;
}
</style>