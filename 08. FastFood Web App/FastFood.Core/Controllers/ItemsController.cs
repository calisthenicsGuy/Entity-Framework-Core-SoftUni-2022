namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Services.Contracts;
    using FastFood.Services.Models.Categories;
    using FastFood.Services.Models.Items;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService;
        private readonly ICategoryService categoryService;

        public ItemsController(IMapper mapper, ICategoryService categoryService, IItemService itemService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Create()
        {
            ICollection<ListCategoryDto> categories = await this.categoryService.GetAll();
            IList<CreateItemViewModel> itemsVms = new List<CreateItemViewModel>();

            foreach (ListCategoryDto categoryDto in categories)
            {
                itemsVms.Add(this.mapper.Map<CreateItemViewModel>(categoryDto));
            }

            return this.View(itemsVms);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Create), "Items");
            }

            bool categoryValid = await this.categoryService.ExistsById(model.CategoryId);
            if (!categoryValid)
            {
                return this.RedirectToAction(nameof(Create), "Items");
            }

            CreateItemDto item = this.mapper.Map<CreateItemDto>(model);
            await this.itemService.Add(item);

            return this.RedirectToAction(nameof(All), "Items");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListItemDto> itemDtos = await this.itemService.GetAll();

            IList<ItemsAllViewModels> itemVms = new List<ItemsAllViewModels>();
            foreach (ListItemDto itemDto in itemDtos)
            {
                itemVms.Add(this.mapper.Map<ItemsAllViewModels>(itemDto));
            }

            return this.View(itemVms);
        }
    }
}
