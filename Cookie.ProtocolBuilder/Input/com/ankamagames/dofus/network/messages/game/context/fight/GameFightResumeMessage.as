package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.action.fight.FightDispellableEffectExtendedInformations;
   import com.ankamagames.dofus.network.types.game.actions.fight.GameActionMark;
   import com.ankamagames.dofus.network.types.game.context.fight.GameFightSpellCooldown;
   import com.ankamagames.dofus.network.types.game.idol.Idol;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightResumeMessage extends GameFightSpectateMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6067;
       
      
      private var _isInitialized:Boolean = false;
      
      public var spellCooldowns:Vector.<GameFightSpellCooldown>;
      
      public var summonCount:uint = 0;
      
      public var bombCount:uint = 0;
      
      private var _spellCooldownstree:FuncTree;
      
      public function GameFightResumeMessage()
      {
         this.spellCooldowns = new Vector.<GameFightSpellCooldown>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6067;
      }
      
      public function initGameFightResumeMessage(param1:Vector.<FightDispellableEffectExtendedInformations> = null, param2:Vector.<GameActionMark> = null, param3:uint = 0, param4:uint = 0, param5:Vector.<Idol> = null, param6:Vector.<GameFightSpellCooldown> = null, param7:uint = 0, param8:uint = 0) : GameFightResumeMessage
      {
         super.initGameFightSpectateMessage(param1,param2,param3,param4,param5);
         this.spellCooldowns = param6;
         this.summonCount = param7;
         this.bombCount = param8;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.spellCooldowns = new Vector.<GameFightSpellCooldown>();
         this.summonCount = 0;
         this.bombCount = 0;
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
         this.serializeAs_GameFightResumeMessage(param1);
      }
      
      public function serializeAs_GameFightResumeMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightSpectateMessage(param1);
         param1.writeShort(this.spellCooldowns.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.spellCooldowns.length)
         {
            (this.spellCooldowns[_loc2_] as GameFightSpellCooldown).serializeAs_GameFightSpellCooldown(param1);
            _loc2_++;
         }
         if(this.summonCount < 0)
         {
            throw new Error("Forbidden value (" + this.summonCount + ") on element summonCount.");
         }
         param1.writeByte(this.summonCount);
         if(this.bombCount < 0)
         {
            throw new Error("Forbidden value (" + this.bombCount + ") on element bombCount.");
         }
         param1.writeByte(this.bombCount);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightResumeMessage(param1);
      }
      
      public function deserializeAs_GameFightResumeMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:GameFightSpellCooldown = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new GameFightSpellCooldown();
            _loc4_.deserialize(param1);
            this.spellCooldowns.push(_loc4_);
            _loc3_++;
         }
         this._summonCountFunc(param1);
         this._bombCountFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightResumeMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightResumeMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._spellCooldownstree = param1.addChild(this._spellCooldownstreeFunc);
         param1.addChild(this._summonCountFunc);
         param1.addChild(this._bombCountFunc);
      }
      
      private function _spellCooldownstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._spellCooldownstree.addChild(this._spellCooldownsFunc);
            _loc3_++;
         }
      }
      
      private function _spellCooldownsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:GameFightSpellCooldown = new GameFightSpellCooldown();
         _loc2_.deserialize(param1);
         this.spellCooldowns.push(_loc2_);
      }
      
      private function _summonCountFunc(param1:ICustomDataInput) : void
      {
         this.summonCount = param1.readByte();
         if(this.summonCount < 0)
         {
            throw new Error("Forbidden value (" + this.summonCount + ") on element of GameFightResumeMessage.summonCount.");
         }
      }
      
      private function _bombCountFunc(param1:ICustomDataInput) : void
      {
         this.bombCount = param1.readByte();
         if(this.bombCount < 0)
         {
            throw new Error("Forbidden value (" + this.bombCount + ") on element of GameFightResumeMessage.bombCount.");
         }
      }
   }
}
