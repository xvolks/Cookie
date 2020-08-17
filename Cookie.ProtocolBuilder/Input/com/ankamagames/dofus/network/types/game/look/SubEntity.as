package com.ankamagames.dofus.network.types.game.look
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class SubEntity implements INetworkType
   {
      
      public static const protocolId:uint = 54;
       
      
      public var bindingPointCategory:uint = 0;
      
      public var bindingPointIndex:uint = 0;
      
      public var subEntityLook:EntityLook;
      
      private var _subEntityLooktree:FuncTree;
      
      public function SubEntity()
      {
         this.subEntityLook = new EntityLook();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 54;
      }
      
      public function initSubEntity(param1:uint = 0, param2:uint = 0, param3:EntityLook = null) : SubEntity
      {
         this.bindingPointCategory = param1;
         this.bindingPointIndex = param2;
         this.subEntityLook = param3;
         return this;
      }
      
      public function reset() : void
      {
         this.bindingPointCategory = 0;
         this.bindingPointIndex = 0;
         this.subEntityLook = new EntityLook();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_SubEntity(param1);
      }
      
      public function serializeAs_SubEntity(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.bindingPointCategory);
         if(this.bindingPointIndex < 0)
         {
            throw new Error("Forbidden value (" + this.bindingPointIndex + ") on element bindingPointIndex.");
         }
         param1.writeByte(this.bindingPointIndex);
         this.subEntityLook.serializeAs_EntityLook(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SubEntity(param1);
      }
      
      public function deserializeAs_SubEntity(param1:ICustomDataInput) : void
      {
         this._bindingPointCategoryFunc(param1);
         this._bindingPointIndexFunc(param1);
         this.subEntityLook = new EntityLook();
         this.subEntityLook.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SubEntity(param1);
      }
      
      public function deserializeAsyncAs_SubEntity(param1:FuncTree) : void
      {
         param1.addChild(this._bindingPointCategoryFunc);
         param1.addChild(this._bindingPointIndexFunc);
         this._subEntityLooktree = param1.addChild(this._subEntityLooktreeFunc);
      }
      
      private function _bindingPointCategoryFunc(param1:ICustomDataInput) : void
      {
         this.bindingPointCategory = param1.readByte();
         if(this.bindingPointCategory < 0)
         {
            throw new Error("Forbidden value (" + this.bindingPointCategory + ") on element of SubEntity.bindingPointCategory.");
         }
      }
      
      private function _bindingPointIndexFunc(param1:ICustomDataInput) : void
      {
         this.bindingPointIndex = param1.readByte();
         if(this.bindingPointIndex < 0)
         {
            throw new Error("Forbidden value (" + this.bindingPointIndex + ") on element of SubEntity.bindingPointIndex.");
         }
      }
      
      private function _subEntityLooktreeFunc(param1:ICustomDataInput) : void
      {
         this.subEntityLook = new EntityLook();
         this.subEntityLook.deserializeAsync(this._subEntityLooktree);
      }
   }
}
