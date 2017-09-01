package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.action.fight.FightDispellableEffectExtendedInformations;
   import com.ankamagames.dofus.network.types.game.actions.fight.GameActionMark;
   import com.ankamagames.dofus.network.types.game.context.fight.GameFightResumeSlaveInfo;
   import com.ankamagames.dofus.network.types.game.context.fight.GameFightSpellCooldown;
   import com.ankamagames.dofus.network.types.game.idol.Idol;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightResumeWithSlavesMessage extends GameFightResumeMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6215;
       
      
      private var _isInitialized:Boolean = false;
      
      public var slavesInfo:Vector.<GameFightResumeSlaveInfo>;
      
      private var _slavesInfotree:FuncTree;
      
      public function GameFightResumeWithSlavesMessage()
      {
         this.slavesInfo = new Vector.<GameFightResumeSlaveInfo>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6215;
      }
      
      public function initGameFightResumeWithSlavesMessage(param1:Vector.<FightDispellableEffectExtendedInformations> = null, param2:Vector.<GameActionMark> = null, param3:uint = 0, param4:uint = 0, param5:Vector.<Idol> = null, param6:Vector.<GameFightSpellCooldown> = null, param7:uint = 0, param8:uint = 0, param9:Vector.<GameFightResumeSlaveInfo> = null) : GameFightResumeWithSlavesMessage
      {
         super.initGameFightResumeMessage(param1,param2,param3,param4,param5,param6,param7,param8);
         this.slavesInfo = param9;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.slavesInfo = new Vector.<GameFightResumeSlaveInfo>();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightResumeWithSlavesMessage(param1);
      }
      
      public function serializeAs_GameFightResumeWithSlavesMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightResumeMessage(param1);
         param1.writeShort(this.slavesInfo.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.slavesInfo.length)
         {
            (this.slavesInfo[_loc2_] as GameFightResumeSlaveInfo).serializeAs_GameFightResumeSlaveInfo(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightResumeWithSlavesMessage(param1);
      }
      
      public function deserializeAs_GameFightResumeWithSlavesMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:GameFightResumeSlaveInfo = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new GameFightResumeSlaveInfo();
            _loc4_.deserialize(param1);
            this.slavesInfo.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightResumeWithSlavesMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightResumeWithSlavesMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._slavesInfotree = param1.addChild(this._slavesInfotreeFunc);
      }
      
      private function _slavesInfotreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._slavesInfotree.addChild(this._slavesInfoFunc);
            _loc3_++;
         }
      }
      
      private function _slavesInfoFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:GameFightResumeSlaveInfo = new GameFightResumeSlaveInfo();
         _loc2_.deserialize(param1);
         this.slavesInfo.push(_loc2_);
      }
   }
}
