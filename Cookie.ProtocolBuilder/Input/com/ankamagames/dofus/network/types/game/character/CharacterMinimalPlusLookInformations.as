package com.ankamagames.dofus.network.types.game.character
{
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class CharacterMinimalPlusLookInformations extends CharacterMinimalInformations implements INetworkType
   {
      
      public static const protocolId:uint = 163;
       
      
      public var entityLook:EntityLook;
      
      private var _entityLooktree:FuncTree;
      
      public function CharacterMinimalPlusLookInformations()
      {
         this.entityLook = new EntityLook();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 163;
      }
      
      public function initCharacterMinimalPlusLookInformations(param1:Number = 0, param2:String = "", param3:uint = 0, param4:EntityLook = null) : CharacterMinimalPlusLookInformations
      {
         super.initCharacterMinimalInformations(param1,param2,param3);
         this.entityLook = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.entityLook = new EntityLook();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CharacterMinimalPlusLookInformations(param1);
      }
      
      public function serializeAs_CharacterMinimalPlusLookInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterMinimalInformations(param1);
         this.entityLook.serializeAs_EntityLook(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterMinimalPlusLookInformations(param1);
      }
      
      public function deserializeAs_CharacterMinimalPlusLookInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.entityLook = new EntityLook();
         this.entityLook.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterMinimalPlusLookInformations(param1);
      }
      
      public function deserializeAsyncAs_CharacterMinimalPlusLookInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._entityLooktree = param1.addChild(this._entityLooktreeFunc);
      }
      
      private function _entityLooktreeFunc(param1:ICustomDataInput) : void
      {
         this.entityLook = new EntityLook();
         this.entityLook.deserializeAsync(this._entityLooktree);
      }
   }
}
