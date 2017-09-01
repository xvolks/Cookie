package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.roleplay.GameRolePlayActorInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayTaxCollectorInformations extends GameRolePlayActorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 148;
       
      
      public var identification:TaxCollectorStaticInformations;
      
      public var guildLevel:uint = 0;
      
      public var taxCollectorAttack:int = 0;
      
      private var _identificationtree:FuncTree;
      
      public function GameRolePlayTaxCollectorInformations()
      {
         this.identification = new TaxCollectorStaticInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 148;
      }
      
      public function initGameRolePlayTaxCollectorInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:TaxCollectorStaticInformations = null, param5:uint = 0, param6:int = 0) : GameRolePlayTaxCollectorInformations
      {
         super.initGameRolePlayActorInformations(param1,param2,param3);
         this.identification = param4;
         this.guildLevel = param5;
         this.taxCollectorAttack = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.identification = new TaxCollectorStaticInformations();
         this.taxCollectorAttack = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayTaxCollectorInformations(param1);
      }
      
      public function serializeAs_GameRolePlayTaxCollectorInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayActorInformations(param1);
         param1.writeShort(this.identification.getTypeId());
         this.identification.serialize(param1);
         if(this.guildLevel < 0 || this.guildLevel > 255)
         {
            throw new Error("Forbidden value (" + this.guildLevel + ") on element guildLevel.");
         }
         param1.writeByte(this.guildLevel);
         param1.writeInt(this.taxCollectorAttack);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayTaxCollectorInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayTaxCollectorInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.identification = ProtocolTypeManager.getInstance(TaxCollectorStaticInformations,_loc2_);
         this.identification.deserialize(param1);
         this._guildLevelFunc(param1);
         this._taxCollectorAttackFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayTaxCollectorInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayTaxCollectorInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._identificationtree = param1.addChild(this._identificationtreeFunc);
         param1.addChild(this._guildLevelFunc);
         param1.addChild(this._taxCollectorAttackFunc);
      }
      
      private function _identificationtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.identification = ProtocolTypeManager.getInstance(TaxCollectorStaticInformations,_loc2_);
         this.identification.deserializeAsync(this._identificationtree);
      }
      
      private function _guildLevelFunc(param1:ICustomDataInput) : void
      {
         this.guildLevel = param1.readUnsignedByte();
         if(this.guildLevel < 0 || this.guildLevel > 255)
         {
            throw new Error("Forbidden value (" + this.guildLevel + ") on element of GameRolePlayTaxCollectorInformations.guildLevel.");
         }
      }
      
      private function _taxCollectorAttackFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorAttack = param1.readInt();
      }
   }
}
