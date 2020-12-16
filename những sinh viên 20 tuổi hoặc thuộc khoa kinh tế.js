db.SinhVien.find({
    $or:[
        {'Tuoi': 20},
        {'Khoa':'Kinh te'}
    ]
}).pretty()