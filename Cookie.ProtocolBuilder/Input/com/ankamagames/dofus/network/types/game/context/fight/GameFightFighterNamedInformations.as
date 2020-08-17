package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.character.status.PlayerStatus;
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameFightFighterNamedInformations extends GameFightFighterInformations implements INetworkType
   {
      
      public static const protocolId:uint = 158;
       
      
      public var name:String = "";
      
      public var status:PlayerStatus;
      
      private var _statustree:FuncTree;
      
      public function GameFightFighterNamedInformations()
      {
         this.status = new PlayerStatus();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 158;
      }
      
      public function initGameFightFighterNamedInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:uint = 2, param5:uint = 0, param6:Boolean = false, param7:GameFightMinimalStats = null, param8:Vector.<uint> = null, param9:String = "", param10:PlayerStatus = null) : GameFightFighterNamedInformations
      {
         super.initGameFightFighterInformations(param1,param2,param3,param4,param5,param6,param7,param8);
         this.name = param9;
         this.status = param10;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.name = "";
         this.status = new PlayerStatus();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightFighterNamedInformations(param1);
      }
      
      public function serializeAs_GameFightFighterNamedInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightFighterInformations(param1);
         param1.writeUTF(this.name);
         this.status.serializeAs_PlayerStatus(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightFighterNamedInformations(param1);
      }
      
      public function deserializeAs_GameFightFighterNamedInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._nameFunc(param1);
         this.status = new PlayerStatus();
         this.status.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightFighterNamedInformations(param1);
      }
      
      public function deserializeAsyncAs_GameFightFighterNamedInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._nameFunc);
         this._statustree = param1.addChild(this._statustreeFunc);
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
      
      private function _statustreeFunc(param1:ICustomDataInput) : void
      {
         this.status = new PlayerStatus();
         this.status.deserializeAsync(this._statustree);
      }
   }
}
