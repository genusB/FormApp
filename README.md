﻿# FormApp

1. Create a web form containing different field types e.g. single-line text, multiple-line text, drop-down, date, radio, and checkboxes.

2. Add client-side validation for your form.

3. Send submissions of your form as JSON-objects to the server. Ex.:

{

field1: 'value1'

field2: true,

field3: ['option1', 'option3']

...

}

4. Implement API for saving and searching the submissions of your form.

5. Create a web page for searching submissions of your form. The search page as well as corresponding API must be universal and should not depend on certain field types the original form consisted of. At the same time, all fields of the original form must be included in the search index. Modifications to the original form e.g. adding/removing fields, changing field types, should not affect API and the search page. If you add new fields to your form, submissions from both forms (prior and after modifications) must be searchable and new fields must be included in the search index automatically.

## Technologies

Client: Vue JS, Bootstrap, TypeScript or ES6/7 with babel, webpack
Server: .NET Core 2+ or 3+
