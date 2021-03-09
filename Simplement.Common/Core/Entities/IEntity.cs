using System;
using System.ComponentModel.DataAnnotations;

namespace SoftLegion.Common.Core.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }

        /// <summary>
        /// Дата создания <c>DateTime</c>
        /// <remarks>
        /// <c><para>Поле является обязательным</para>
        /// <para>Значение поля присваивается при создании и остаётся неизменным всё время жизни записи</para></c></remarks>
        /// </summary>
        [DataType(DataType.Date)]
        [Display(ResourceType = typeof(CommonResources), Name = "Entity_CreationDate")]
        DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата последнего изменения <c>DateTime</c>
        /// <remarks>
        /// <c><para>Поле является обязательным</para>
        /// <para>Значение поля автоматически переписывается при обновлении записи</para></c></remarks>
        /// </summary>
	    [DataType(DataType.Date)]
        [Display(ResourceType = typeof(CommonResources), Name = "Entity_LastModifiedDate")]
        DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Пометка "Активная запись" <c>bool</c>
        /// <remarks>
        /// <c><para>Поле является обязательным</para>
        /// <para>Записи в БД не удаляются, а лишь помечаются как неактивные</para></c></remarks>
        /// </summary>
        [Display(ResourceType = typeof(CommonResources), Name = "Entity_IsActive")]
        bool IsActive { get; set; }

        /// <summary>
        /// Id- пользователя создавшего запись <c>Guid</c>
        /// <remarks>
        /// <c>
        /// <para>Поле является обязательным</para>
        /// <para>Значение поля присваивается при создании и остаётся неизменным всё время жизни записи</para></c></remarks>
        /// </summary>
        Guid? CreatedByUserId { get; set; }

        /// <summary>
        /// Id- пользователя изменившего запись <c>Guid</c>
        /// <remarks>
        /// <c>
        /// <para>Поле является обязательным</para>
        /// <para>Значение поля автоматически переписывается при обновлении записи</para></c></remarks>
        /// </summary>
        Guid? LastModifiedUserId { get; set; }
    }
}