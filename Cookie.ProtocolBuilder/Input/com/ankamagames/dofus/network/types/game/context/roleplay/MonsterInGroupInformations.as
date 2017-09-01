package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class MonsterInGroupInformations extends MonsterInGroupLightInformations implements INetworkType
   {
      
      public static const protocolId:uint = 144;
       
      
      public var look:EntityLook;
      
      private var _looktree:FuncTree;
      
      public function MonsterInGroupInformations()
      {
         this.look = new EntityLook();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 144;
      }
      
      public function initMonsterInGroupInformations(param1:int = 0, param2:uint = 0, param3:EntityLook = null) : MonsterInGroupInformations
      {
         super.initMonsterInGroupLightInformations(param1,param2);
         this.look = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.look = new EntityLook();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MonsterInGroupInformations(param1);
      }
      
      public function serializeAs_MonsterInGroupInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_MonsterInGroupLightInformations(param1);
         this.look.serializeAs_EntityLook(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MonsterInGroupInformations(param1);
      }
      
      public function deserializeAs_MonsterInGroupInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.look = new EntityLook();
         this.look.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MonsterInGroupInformations(param1);
      }
      
      public function deserializeAsyncAs_MonsterInGroupInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._looktree = param1.addChild(this._looktreeFunc);
      }
      
      private function _looktreeFunc(param1:ICustomDataInput) : void
      {
         this.look = new EntityLook();
         this.look.deserializeAsync(this._looktree);
      }
   }
}
