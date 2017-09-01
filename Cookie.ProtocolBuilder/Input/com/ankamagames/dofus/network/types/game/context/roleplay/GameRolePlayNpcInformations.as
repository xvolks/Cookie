package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayNpcInformations extends GameRolePlayActorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 156;
       
      
      public var npcId:uint = 0;
      
      public var sex:Boolean = false;
      
      public var specialArtworkId:uint = 0;
      
      public function GameRolePlayNpcInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 156;
      }
      
      public function initGameRolePlayNpcInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:uint = 0, param5:Boolean = false, param6:uint = 0) : GameRolePlayNpcInformations
      {
         super.initGameRolePlayActorInformations(param1,param2,param3);
         this.npcId = param4;
         this.sex = param5;
         this.specialArtworkId = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.npcId = 0;
         this.sex = false;
         this.specialArtworkId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayNpcInformations(param1);
      }
      
      public function serializeAs_GameRolePlayNpcInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayActorInformations(param1);
         if(this.npcId < 0)
         {
            throw new Error("Forbidden value (" + this.npcId + ") on element npcId.");
         }
         param1.writeVarShort(this.npcId);
         param1.writeBoolean(this.sex);
         if(this.specialArtworkId < 0)
         {
            throw new Error("Forbidden value (" + this.specialArtworkId + ") on element specialArtworkId.");
         }
         param1.writeVarShort(this.specialArtworkId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayNpcInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayNpcInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._npcIdFunc(param1);
         this._sexFunc(param1);
         this._specialArtworkIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayNpcInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayNpcInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._npcIdFunc);
         param1.addChild(this._sexFunc);
         param1.addChild(this._specialArtworkIdFunc);
      }
      
      private function _npcIdFunc(param1:ICustomDataInput) : void
      {
         this.npcId = param1.readVarUhShort();
         if(this.npcId < 0)
         {
            throw new Error("Forbidden value (" + this.npcId + ") on element of GameRolePlayNpcInformations.npcId.");
         }
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
      }
      
      private function _specialArtworkIdFunc(param1:ICustomDataInput) : void
      {
         this.specialArtworkId = param1.readVarUhShort();
         if(this.specialArtworkId < 0)
         {
            throw new Error("Forbidden value (" + this.specialArtworkId + ") on element of GameRolePlayNpcInformations.specialArtworkId.");
         }
      }
   }
}
