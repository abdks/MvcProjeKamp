﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class IMageFıleManager: IImageFileService
    {
        IImageFileDal _ımageFileDal;

        public IMageFıleManager(IImageFileDal ımageFileDal)
        {
            _ımageFileDal = ımageFileDal;
        }

        public List<ImageFile> GetList()
        {
            return _ımageFileDal.List();
        }
    }
}
